using HalconDotNet;

namespace HalconCalibration.Common;

public class QRCodeCtrl {
    private static readonly QRCodeCtrl _instance = new QRCodeCtrl();
    public static QRCodeCtrl Instance => _instance;

    private QRCodeCtrl() { }

    // 二维码识别结果
    public string? QRCodeString{ get; set; }
    
    // 二维码位置信息
    public HTuple? Row{ get; set; }
    public HTuple? Column{ get; set; }
    public HTuple? Phi{ get; set; }
    public HTuple? Length1{ get; set; }
    public HTuple? Length2{ get; set; }

    /// <summary>
    /// 二维码识别函数
    /// </summary>
    /// <param name="window">Halcon窗口对象</param>
    /// <param name="errorMsg">错误信息</param>
    /// <returns>识别是否成功</returns>
    public bool HandleQRCode(HWindow? window, out string? errorMsg) {
        HDataCode2D? dataCodeModel = null;
        try {
            if (CameraCtrl.Instance.Image == null) throw new Exception("图像未加载");

            // 创建二维码数据代码模型
            dataCodeModel = new HDataCode2D();
            
            // 设置二维码类型为QR Code
            dataCodeModel.SetDataCode2dParam("symbol_type", "QR Code");
            
            // 在图像中查找二维码
            HTuple resultHandles = new HTuple();
            HTuple decodedDataStrings = new HTuple();
            
            // 查找二维码（正确的API签名：图像、通用参数名、通用参数值、输出结果句柄、输出解码字符串）
            dataCodeModel.FindDataCode2d(
                CameraCtrl.Instance.Image,
                new HTuple(),
                new HTuple(),
                out resultHandles,
                out decodedDataStrings
            );
            
            // 初始化位置信息（如果API不支持直接获取位置，则设为默认值）
            HTuple row = new HTuple();
            HTuple column = new HTuple();
            HTuple phi = new HTuple();
            HTuple length1 = new HTuple();
            HTuple length2 = new HTuple();

            // 检查是否找到二维码
            if (decodedDataStrings.Length > 0 && decodedDataStrings[0].S != null) {
                QRCodeString = decodedDataStrings[0].S;
                Row = row;
                Column = column;
                Phi = phi;
                Length1 = length1;
                Length2 = length2;

                // 在窗口中显示图像和二维码区域
                window?.ClearWindow();
                CameraCtrl.Instance.Image.DispObj(window);
                
                // 绘制二维码区域（椭圆）
                if (row.Length > 0 && column.Length > 0) {
                    for (int i = 0; i < row.Length; i++) {
                        HXLDCont ellipse = new HXLDCont();
                        ellipse.GenEllipseContourXld(
                            row[i].D,
                            column[i].D,
                            phi[i].D,
                            length1[i].D,
                            length2[i].D,
                            0,
                            6.28318,
                            "positive",
                            1.0
                        );
                        ellipse.DispObj(window);
                        ellipse.Dispose();
                    }
                }

                errorMsg = null;
                return true;
            }
            else {
                // 未找到二维码，只显示图像
                window?.ClearWindow();
                CameraCtrl.Instance.Image.DispObj(window);
                
                QRCodeString = null;
                Row = null;
                Column = null;
                Phi = null;
                Length1 = null;
                Length2 = null;
                
                errorMsg = "未检测到二维码";
                return false;
            }
        }
        catch (Exception exception) {
            errorMsg = $"二维码识别失败：{exception.Message}";
            QRCodeString = null;
            Row = null;
            Column = null;
            Phi = null;
            Length1 = null;
            Length2 = null;
            return false;
        }
        finally {
            // 释放资源
            dataCodeModel?.Dispose();
        }
    }
}

