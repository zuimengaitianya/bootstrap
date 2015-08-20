using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using NPOI.HSSF.UserModel;
using System.Web;
using NPOI.HSSF.Util;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace TelnetMVC.Common
{
    public class ExcelHelper
    {
        /// <summary>
        ///  DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dt">源DataTable</param>
        /// <param name="subject">表头文本</param>
        /// <returns></returns>
        public static MemoryStream DataTableToExcel(DataTable dt, string subject)
        {
            int rowCount = dt.Rows.Count;		//DataTable行数
            int colCount = dt.Columns.Count;	//DataTable列数
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();

            //create a entry of DocumentSummaryInformation
            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "DJI";
                hssfworkbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "大疆创新科技"; //填加xls文件作者信息   
                si.ApplicationName = "大疆创新"; //填加xls文件创建程序信息   
                si.LastAuthor = "大疆创新"; //填加xls文件最后保存者信息   
                si.Comments = "说明信息"; //填加xls文件作者信息   
                si.Title = subject; //填加xls文件标题信息   
                si.Subject = subject;//填加文件主题信息   
                si.CreateDateTime = DateTime.Now;
                hssfworkbook.SummaryInformation = si;
            }
            #endregion

            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
            IRow rowi = sheet1.CreateRow(0);
            // 设置行宽度
            sheet1.SetColumnWidth(0, 50 * 80);
            sheet1.SetColumnWidth(1, 50 * 90);
            sheet1.SetColumnWidth(2, 50 * 50);
            sheet1.SetColumnWidth(3, 50 * 140);
            sheet1.SetColumnWidth(4, 50 * 150);
            sheet1.SetColumnWidth(5, 50 * 50);
            sheet1.SetColumnWidth(6, 50 * 80);
            sheet1.SetColumnWidth(7, 50 * 80);
            sheet1.SetColumnWidth(8, 50 * 30);
            sheet1.SetColumnWidth(9, 50 * 30);
            sheet1.SetColumnWidth(10, 50 * 60);
            sheet1.SetColumnWidth(11, 50 * 80);
            sheet1.SetColumnWidth(12, 50 * 80);
            sheet1.SetColumnWidth(13, 50 * 50);
            sheet1.SetColumnWidth(14, 50 * 50);
            sheet1.SetColumnWidth(15, 50 * 60);
            sheet1.SetColumnWidth(16, 50 * 50);
            sheet1.SetColumnWidth(17, 50 * 120);
            sheet1.SetColumnWidth(18, 50 * 100);
            sheet1.SetColumnWidth(19, 50 * 120);
            sheet1.SetColumnWidth(20, 50 * 120);
            sheet1.SetColumnWidth(21, 50 * 100);
            sheet1.SetColumnWidth(22, 50 * 50);
            sheet1.SetColumnWidth(23, 50 * 50);
            sheet1.SetColumnWidth(24, 50 * 50);
            sheet1.SetColumnWidth(25, 50 * 50);
            sheet1.SetColumnWidth(26, 50 * 50);
            sheet1.SetColumnWidth(27, 50 * 50);
            sheet1.SetColumnWidth(28, 50 * 50);
            sheet1.SetColumnWidth(29, 50 * 50);
            sheet1.SetColumnWidth(30, 50 * 60);
            sheet1.SetColumnWidth(31, 50 * 50);
            sheet1.SetColumnWidth(32, 50 * 80);
            sheet1.SetColumnWidth(33, 50 * 120);
            sheet1.SetColumnWidth(34, 50 * 120);
            //rowi.RowStyle.FillBackgroundColor = HSSFColor.Red.Index;
            // HSSFCellStyle setBorder = hssfworkbook.CreateCellStyle();
            HSSFCellStyle titleStyle = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
            //newCell.FillBackgroundColor = HSSFColor.Red.Index ;
            titleStyle.FillForegroundColor = HSSFColor.BlueGrey.Index;
            titleStyle.FillPattern = FillPattern.SolidForeground;
            titleStyle.FillForegroundColor = HSSFColor.Yellow.Index;
            // HSSFRow headerRow = (HSSFRow)sheet1.CreateRow(0);
            //  headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
            for (int i = 0; i < colCount; i++)
            {

                // rowi.CreateCell(i).CellStyle = titleStyle;
                // rowi.CreateCell(i).CellStyle.BottomBorderColor=
                // headStyle.FillBackgroundColor
                rowi.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName.ToString());
                rowi.GetCell(i).CellStyle = titleStyle;
            }

            for (int j = 1; j <= rowCount; j++)
            {
                IRow rowj = sheet1.CreateRow(j);
                for (int k = 0; k < colCount; k++)
                {
                    rowj.CreateCell(k).SetCellValue(dt.Rows[j - 1][k].ToString());
                }
            }
            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            return file;
        }

        ///// <summary>   
        ///// DataTable导出到Excel的MemoryStream   
        ///// </summary>   
        ///// <param name="dtSource">源DataTable</param>   
        ///// <param name="strHeaderText">表头文本</param>   

        ///// <summary>   
        ///// 用于Web导出   
        ///// </summary>   
        ///// <param name="dtSource">源DataTable</param>   
        ///// <param name="strHeaderText">表头文本</param>   
        ///// <param name="strFileName">文件名</param>   
        //public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName)
        //{

        //    HttpContext curContext = HttpContext.Current;

        //    // 设置编码和附件格式   
        //    curContext.Response.ContentType = "application/vnd.ms-excel";
        //    curContext.Response.ContentEncoding = Encoding.UTF8;
        //    curContext.Response.Charset = "";
        //    curContext.Response.AppendHeader("Content-Disposition",
        //        "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));

        //    curContext.Response.BinaryWrite(Export(dtSource, strHeaderText).GetBuffer());
        //   // curContext.Response.End();

        //    curContext.ApplicationInstance.CompleteRequest();

        //}



        ///// <summary>   
        ///// 用于Web导出   
        ///// </summary>   
        ///// <param name="dtSource">源DataTable</param>   
        ///// <param name="strHeaderText">表头文本</param>   
        ///// <param name="strFileName">文件名</param>   
        //public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName, bool specificTime)
        //{

        //    HttpContext curContext = HttpContext.Current;

        //    // 设置编码和附件格式   
        //    curContext.Response.ContentType = "application/vnd.ms-excel";
        //    curContext.Response.ContentEncoding = Encoding.UTF8;
        //    curContext.Response.Charset = "";
        //    curContext.Response.AppendHeader("Content-Disposition",
        //        "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));

        //    curContext.Response.BinaryWrite(Export(dtSource, strHeaderText, specificTime).GetBuffer());
        //    //  curContext.Response.End();
        //    curContext.ApplicationInstance.CompleteRequest();


        //}

        /// <summary>
        /// Excel导入到DataTable
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string filePath)
        {
            IWorkbook hssfworkbook;
            #region//初始化信息
            try
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = WorkbookFactory.Create(file);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            #endregion

            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            DataTable dt = new DataTable();
            //for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
            //{
            //    dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
            //}
            IRow row1 = sheet.GetRow(0);
            for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
            {
                dt.Columns.Add(row1.GetCell(j).ToString());
            }


            try
            {
                for (int j = 1; j <= sheet.LastRowNum; j++)
                {
                    IRow row = sheet.GetRow(j);
                    if (row == null) continue;
                    DataRow dr = dt.NewRow();

                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        ICell cell = row.GetCell(i);
                        if (cell == null)
                        {
                            dr[i] = null;
                        }
                        else
                        {
                            dr[i] = cell.ToString();
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return dt;
        }

        /// <summary>   
        /// DataTable导出到Excel的MemoryStream   
        /// </summary>   
        /// <param name="dtSource">源DataTable</param>   
        /// <param name="strHeaderText">表头文本</param>   
        public static MemoryStream Export(DataTable dtSource, string strHeaderText, bool specificTime)
        {
            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("Sheet1");

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "";
                workbook.DocumentSummaryInformation = dsi;
                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "冠畅1"; //填加xls文件作者信息   
                si.ApplicationName = "冠畅2"; //填加xls文件创建程序信息   
                si.LastAuthor = "冠畅3"; //填加xls文件最后保存者信息   
                si.Comments = "说明信息"; //填加xls文件作者信息   
                si.Title = strHeaderText; //填加xls文件标题信息   
                si.Subject = strHeaderText;//填加文件主题信息   
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            var dateStyle = workbook.CreateCellStyle();
            var format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat(specificTime ? "yyyy-mm-dd HH:mm:ss" : "yyyy-mm-dd");

            //取得列宽   
            var arrColWidth = new int[dtSource.Columns.Count];

            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式
                    {
                        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                        HSSFFont font = (HSSFFont)workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        headerRow.GetCell(0).CellStyle = headStyle;

                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));//new Region(0, 0, 0, dtSource.Columns.Count - 1)
                        // headerRow.Dispose();
                    }
                    #endregion


                    #region 列头及样式
                    {
                        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(1);


                        HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        HSSFFont font = (HSSFFont)workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);


                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽   
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                        }
                        //   headerRow.Dispose();
                    }
                    #endregion

                    rowIndex = 2;
                }
                #endregion
                #region 填充内容
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {

                        case "System.String"://字符串类型   
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型   
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);
                            newCell.CellStyle = dateStyle;//格式化显示   
                            break;
                        case "System.Boolean"://布尔型   
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型   
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型   
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理   
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion
                rowIndex++;
            }
            using (var ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                // sheet.Dispose();
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet   
                return ms;
            }
        }

        public static MemoryStream ExportSingleOrder(DataRow drSource, DataRow extendSource, string strHeaderText)
        {
            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("Sheet1");

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "";
                workbook.DocumentSummaryInformation = dsi;
                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "远古1"; //填加xls文件作者信息   
                si.ApplicationName = "远古2"; //填加xls文件创建程序信息   
                si.LastAuthor = "远古3"; //填加xls文件最后保存者信息   
                si.Comments = "说明信息"; //填加xls文件作者信息   
                si.Title = strHeaderText; //填加xls文件标题信息   
                si.Subject = strHeaderText;//填加文件主题信息   
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion


            int rowCount = drSource.Table.Columns.Count / 3;
            int colCount = drSource.Table.Columns.Count > 6 ? 6 : drSource.Table.Columns.Count;

            //标题
            HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
            headerRow.HeightInPoints = 25;
            headerRow.CreateCell(0).SetCellValue(strHeaderText);

            HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFFont font = (HSSFFont)workbook.CreateFont();
            font.FontHeightInPoints = 20;
            font.Boldweight = 700;
            headStyle.SetFont(font);
            headStyle.Alignment = HorizontalAlignment.Center;
            headStyle.VerticalAlignment = VerticalAlignment.Center;
            headStyle.BorderBottom = BorderStyle.Thin;
            headStyle.BorderLeft = BorderStyle.Thin;
            headStyle.BorderRight = BorderStyle.Thin;
            headStyle.BorderTop = BorderStyle.Thin;
            headStyle.BottomBorderColor = HSSFColor.Black.Index;
            headStyle.LeftBorderColor = HSSFColor.Black.Index;
            headStyle.RightBorderColor = HSSFColor.Black.Index;
            headStyle.TopBorderColor = HSSFColor.Black.Index;
            headerRow.GetCell(0).CellStyle = headStyle;
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 6));

            //样式
            //列名
            HSSFCellStyle titleStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFFont titlefont = (HSSFFont)workbook.CreateFont();
            titlefont.FontHeightInPoints = 16;
            titleStyle.SetFont(titlefont);
            titleStyle.FillForegroundColor = HSSFColor.BlueGrey.Index;
            titleStyle.FillPattern = FillPattern.SolidForeground;
            titleStyle.Alignment = HorizontalAlignment.Left;
            titleStyle.VerticalAlignment = VerticalAlignment.Center;
            titleStyle.ShrinkToFit = true;
            titleStyle.BorderBottom = BorderStyle.Thin;
            titleStyle.BorderLeft = BorderStyle.Thin;
            titleStyle.BorderRight = BorderStyle.Thin;
            titleStyle.BorderTop = BorderStyle.Thin;
            titleStyle.BottomBorderColor = HSSFColor.Black.Index;
            titleStyle.LeftBorderColor = HSSFColor.Black.Index;
            titleStyle.RightBorderColor = HSSFColor.Black.Index;
            titleStyle.TopBorderColor = HSSFColor.Black.Index;

            //文本
            HSSFCellStyle txtStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFFont txtfont = (HSSFFont)workbook.CreateFont();
            txtfont.FontHeightInPoints = 16;
            txtStyle.SetFont(txtfont);
            txtStyle.Alignment = HorizontalAlignment.Left;
            txtStyle.VerticalAlignment = VerticalAlignment.Center;
            txtStyle.ShrinkToFit = true;
            txtStyle.BorderBottom = BorderStyle.Thin;
            txtStyle.BorderLeft = BorderStyle.Thin;
            txtStyle.BorderRight = BorderStyle.Thin;
            txtStyle.BorderTop = BorderStyle.Thin;
            txtStyle.BottomBorderColor = HSSFColor.Black.Index;
            txtStyle.LeftBorderColor = HSSFColor.Black.Index;
            txtStyle.RightBorderColor = HSSFColor.Black.Index;
            txtStyle.TopBorderColor = HSSFColor.Black.Index;

            //date1
            var format = workbook.CreateDataFormat();
            HSSFCellStyle dateStyle1 = (HSSFCellStyle)workbook.CreateCellStyle();
            dateStyle1.DataFormat = format.GetFormat("yyyy-mm-dd HH:mm:ss");
            dateStyle1.Alignment = HorizontalAlignment.Center;
            dateStyle1.VerticalAlignment = VerticalAlignment.Center;
            dateStyle1.SetFont(txtfont);
            dateStyle1.BorderBottom = BorderStyle.Thin;
            dateStyle1.BorderLeft = BorderStyle.Thin;
            dateStyle1.BorderRight = BorderStyle.Thin;
            dateStyle1.BorderTop = BorderStyle.Thin;
            dateStyle1.BottomBorderColor = HSSFColor.Black.Index;
            dateStyle1.LeftBorderColor = HSSFColor.Black.Index;
            dateStyle1.RightBorderColor = HSSFColor.Black.Index;
            dateStyle1.TopBorderColor = HSSFColor.Black.Index;
            HSSFCellStyle dateStyle2 = (HSSFCellStyle)workbook.CreateCellStyle();
            dateStyle2.DataFormat = format.GetFormat("yyyy-mm-dd HH:mm");
            dateStyle2.Alignment = HorizontalAlignment.Center;
            dateStyle2.VerticalAlignment = VerticalAlignment.Center;
            dateStyle2.SetFont(txtfont);
            dateStyle2.BorderBottom = BorderStyle.Thin;
            dateStyle2.BorderLeft = BorderStyle.Thin;
            dateStyle2.BorderRight = BorderStyle.Thin;
            dateStyle2.BorderTop = BorderStyle.Thin;
            dateStyle2.BottomBorderColor = HSSFColor.Black.Index;
            dateStyle2.LeftBorderColor = HSSFColor.Black.Index;
            dateStyle2.RightBorderColor = HSSFColor.Black.Index;
            dateStyle2.TopBorderColor = HSSFColor.Black.Index;
            HSSFCellStyle dateStyle3 = (HSSFCellStyle)workbook.CreateCellStyle();
            dateStyle3.DataFormat = format.GetFormat("yyyy-mm-dd");
            dateStyle3.Alignment = HorizontalAlignment.Center;
            dateStyle3.VerticalAlignment = VerticalAlignment.Center;
            dateStyle3.SetFont(txtfont);
            dateStyle3.BorderBottom = BorderStyle.Thin;
            dateStyle3.BorderLeft = BorderStyle.Thin;
            dateStyle3.BorderRight = BorderStyle.Thin;
            dateStyle3.BorderTop = BorderStyle.Thin;
            dateStyle3.BottomBorderColor = HSSFColor.Black.Index;
            dateStyle3.LeftBorderColor = HSSFColor.Black.Index;
            dateStyle3.RightBorderColor = HSSFColor.Black.Index;
            dateStyle3.TopBorderColor = HSSFColor.Black.Index;
            HSSFCellStyle dateStyle4 = (HSSFCellStyle)workbook.CreateCellStyle();
            dateStyle4.DataFormat = format.GetFormat("HH:mm:ss");
            dateStyle4.Alignment = HorizontalAlignment.Center;
            dateStyle4.VerticalAlignment = VerticalAlignment.Center;
            dateStyle4.SetFont(txtfont);
            dateStyle4.BorderBottom = BorderStyle.Thin;
            dateStyle4.BorderLeft = BorderStyle.Thin;
            dateStyle4.BorderRight = BorderStyle.Thin;
            dateStyle4.BorderTop = BorderStyle.Thin;
            dateStyle4.BottomBorderColor = HSSFColor.Black.Index;
            dateStyle4.LeftBorderColor = HSSFColor.Black.Index;
            dateStyle4.RightBorderColor = HSSFColor.Black.Index;
            dateStyle4.TopBorderColor = HSSFColor.Black.Index;


            //订单公用信息
            //订单编号
            HSSFRow row1 = (HSSFRow)sheet.CreateRow(1);
            SetAndFormateCell("订单编号", row1, 0, titleStyle);
            SetAndFormateCell(drSource, drSource.Table.Columns["OrderNo"], row1, 1, txtStyle);
            //
            if (drSource["BizType"].ToString() == "6")
            {
                SetAndFormateCell("定金(元)", row1, 2, titleStyle);
                SetAndFormateCell(extendSource, extendSource.Table.Columns["TotalPayable"], row1, 3, txtStyle);
            }
            else if (drSource["BizType"].ToString() == "4")
            {
                SetAndFormateCell("定金(元)", row1, 2, titleStyle);
                SetAndFormateCell(drSource, drSource.Table.Columns["TotalPayable"], row1, 3, txtStyle);
            }
            else
            {
                SetAndFormateCell("总金额", row1, 2, titleStyle);
                SetAndFormateCell(drSource, drSource.Table.Columns["TotalPayable"], row1, 3, txtStyle);
            }


            SetAndFormateCell("开单日期", row1, 4, titleStyle);
            SetAndFormateCell(drSource, drSource.Table.Columns["CreateDate"], row1, 5, dateStyle1);

            HSSFRow row2, row3, row4, row5;
            switch (drSource["BizType"].ToString())
            {
                case "1":
                    row2 = (HSSFRow)sheet.CreateRow(2);
                    SetAndFormateCell("俱乐部", row2, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["ChnName"], row2, 1, txtStyle);
                    //
                    SetAndFormateCell("球会套餐", row2, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["PriceName"], row2, 3, txtStyle);

                    SetAndFormateCell("打球日期", row2, 4, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["PlayDate"], row2, 5, dateStyle2);

                    row3 = (HSSFRow)sheet.CreateRow(3);
                    SetAndFormateCell("打球人", row3, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["PlayerName"], row3, 1, txtStyle);
                    //
                    SetAndFormateCell("联系电话", row3, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["MobileNo"], row3, 3, txtStyle);

                    SetAndFormateCell("打球人数", row3, 4, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["Quantity"], row3, 5, txtStyle);

                    row4 = (HSSFRow)sheet.CreateRow(4);
                    SetAndFormateCell("预定规则", row4, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["BookingRule"], row4, 1, txtStyle);

                    break;
                case "2":
                    row2 = (HSSFRow)sheet.CreateRow(2);
                    SetAndFormateCell("酒店名称", row2, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["HotelName"], row2, 1, txtStyle);
                    //
                    SetAndFormateCell("房间类型", row2, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["RoomName"], row2, 3, txtStyle);

                    SetAndFormateCell("房间数量", row2, 4, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["NumberOfRooms"], row2, 5, txtStyle);

                    row3 = (HSSFRow)sheet.CreateRow(3);
                    SetAndFormateCell("入住日期", row3, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["ArrivalDate"], row3, 1, dateStyle3);
                    //
                    SetAndFormateCell("离店日期", row3, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["LeaveDate"], row3, 3, dateStyle3);

                    SetAndFormateCell("确认方式", row3, 4, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["ConfirmationType"], row3, 5, txtStyle);

                    row4 = (HSSFRow)sheet.CreateRow(4);
                    SetAndFormateCell("预订人", row4, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["ContactPerson"], row4, 1, txtStyle);

                    SetAndFormateCell("预订人手机", row4, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["MobileNo"], row4, 3, txtStyle);

                    break;
                case "3":
                    row2 = (HSSFRow)sheet.CreateRow(2);
                    SetAndFormateCell("餐厅名称", row2, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["ChnName"], row2, 1, txtStyle);
                    //
                    SetAndFormateCell("就餐位置", row2, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["SiteName"], row2, 3, txtStyle);

                    SetAndFormateCell("桌台标签", row2, 4, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["TableLabelName"], row2, 5, txtStyle);

                    row3 = (HSSFRow)sheet.CreateRow(3);
                    SetAndFormateCell("就餐时间", row3, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["DiningTime"], row3, 1, dateStyle2);
                    //
                    SetAndFormateCell("预订人数", row3, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["Quantity"], row3, 3, txtStyle);

                    SetAndFormateCell("联系人", row3, 4, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["ContactPerson"], row3, 5, txtStyle);

                    row4 = (HSSFRow)sheet.CreateRow(4);
                    SetAndFormateCell("联系电话", row4, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["MobileNo"], row4, 1, txtStyle);

                    SetAndFormateCell("备注", row4, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["Remarks"], row4, 3, txtStyle);

                    break;
                case "4":
                    string type = drSource["Type"].ToString();
                    row2 = (HSSFRow)sheet.CreateRow(2);
                    SetAndFormateCell("预订类型", row2, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["TypeName"], row2, 1, txtStyle);
                    //
                    SetAndFormateCell("商品名称", row2, 2, titleStyle);
                    SetAndFormateCell(extendSource, extendSource.Table.Columns["Name"], row2, 3, txtStyle);

                    SetAndFormateCell("商品价格", row2, 4, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["Price"], row2, 5, txtStyle);

                    switch (type)
                    {
                        case "1":
                            row3 = (HSSFRow)sheet.CreateRow(3);
                            SetAndFormateCell("商品产地", row3, 0, titleStyle);
                            SetAndFormateCell(extendSource, extendSource.Table.Columns["MadePlace"], row3, 1, txtStyle);
                            //
                            SetAndFormateCell("商品尺寸", row3, 2, titleStyle);
                            SetAndFormateCell(extendSource, extendSource.Table.Columns["Size"], row3, 3, txtStyle);

                            SetAndFormateCell("数量", row3, 4, titleStyle);
                            SetAndFormateCell(drSource, drSource.Table.Columns["Quantity"], row3, 5, txtStyle);
                            break;
                        case "2":
                            row3 = (HSSFRow)sheet.CreateRow(3);
                            SetAndFormateCell("年限", row3, 0, titleStyle);
                            SetAndFormateCell(extendSource, extendSource.Table.Columns["LimitYears"], row3, 1, txtStyle);

                            SetAndFormateCell("数量", row3, 2, titleStyle);
                            SetAndFormateCell(drSource, drSource.Table.Columns["Quantity"], row3, 3, txtStyle);
                            break;
                        case "3":
                            row3 = (HSSFRow)sheet.CreateRow(3);
                            SetAndFormateCell("租赁开始时间", row3, 0, titleStyle);
                            SetAndFormateCell(drSource, drSource.Table.Columns["TourStartTime"], row3, 1, dateStyle2);
                            //
                            SetAndFormateCell("租赁结束时间", row3, 2, titleStyle);
                            SetAndFormateCell(drSource, drSource.Table.Columns["TourEndTime"], row3, 3, dateStyle2);

                            SetAndFormateCell("时间(小时)", row3, 4, titleStyle);
                            SetAndFormateCell(drSource, drSource.Table.Columns["Quantity"], row3, 5, txtStyle);

                            row4 = (HSSFRow)sheet.CreateRow(4);
                            SetAndFormateCell("匹配路线", row4, 0, titleStyle);
                            SetAndFormateCell(extendSource, extendSource.Table.Columns["TourRouteName"], row4, 1, txtStyle);

                            break;
                        case "4":
                            row3 = (HSSFRow)sheet.CreateRow(3);
                            SetAndFormateCell("开班时间", row3, 0, titleStyle);
                            SetAndFormateCell(extendSource, extendSource.Table.Columns["StartDate"], row3, 1, txtStyle);
                            //
                            SetAndFormateCell("报名开始时间", row3, 2, titleStyle);
                            SetAndFormateCell(extendSource, extendSource.Table.Columns["StartJoinDate"], row3, 3, dateStyle3);

                            SetAndFormateCell("报名截止时间", row3, 4, titleStyle);
                            SetAndFormateCell(extendSource, extendSource.Table.Columns["EndJoinDate"], row3, 5, dateStyle3);

                            row4 = (HSSFRow)sheet.CreateRow(4);
                            SetAndFormateCell("人数", row4, 0, titleStyle);
                            SetAndFormateCell(drSource, drSource.Table.Columns["Quantity"], row4, 1, txtStyle);
                            break;
                    }
                    break;
                case "5":
                    row2 = (HSSFRow)sheet.CreateRow(2);
                    SetAndFormateCell("商户名称", row2, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["ChnName"], row2, 1, txtStyle);
                    //
                    SetAndFormateCell("标题名称", row2, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["FirstTitle"], row2, 3, txtStyle);

                    SetAndFormateCell("出发地", row2, 4, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["StartCity"], row2, 5, txtStyle);

                    row3 = (HSSFRow)sheet.CreateRow(3);
                    SetAndFormateCell("目的地", row3, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["DestinationCity"], row3, 1, txtStyle);
                    //
                    SetAndFormateCell("途径地", row3, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["PassCity"], row3, 3, txtStyle);

                    SetAndFormateCell("出发日期", row3, 4, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["DeparTime"], row3, 5, dateStyle3);

                    row4 = (HSSFRow)sheet.CreateRow(4);
                    SetAndFormateCell("出发人数", row4, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["Quantity"], row4, 1, txtStyle);

                    break;
                case "6":
                    row2 = (HSSFRow)sheet.CreateRow(2);
                    SetAndFormateCell("飞机名称", row2, 0, titleStyle);
                    SetAndFormateCell(extendSource, extendSource.Table.Columns["Model"], row2, 1, txtStyle);
                    //
                    SetAndFormateCell("飞行日期", row2, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["PlaneStartTime"], row2, 3, dateStyle3);

                    SetAndFormateCell("旅客人数", row2, 4, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["PassengerNum"], row2, 5, txtStyle);

                    row3 = (HSSFRow)sheet.CreateRow(3);
                    SetAndFormateCell("起飞机场", row3, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["StartCity"], row3, 1, txtStyle);
                    //
                    SetAndFormateCell("达到机场", row3, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["EndCity"], row3, 3, txtStyle);

                    SetAndFormateCell("起飞时间", row3, 4, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["StartTime"], row3, 5, dateStyle4);

                    row4 = (HSSFRow)sheet.CreateRow(4);
                    SetAndFormateCell("到达时间", row4, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["EndTime"], row4, 1, dateStyle4);

                    SetAndFormateCell((drSource["Fax"] == DBNull.Value ? "Email" : "Fax"), row4, 0, titleStyle);
                    SetAndFormateCell(drSource, (drSource["Fax"] == DBNull.Value ? drSource.Table.Columns["Email"] : drSource.Table.Columns["Fax"]), row4, 1, txtStyle);

                    SetAndFormateCell("是否需要宣传册", row4, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["NeedBrochure"], row4, 1, txtStyle);

                    row5 = (HSSFRow)sheet.CreateRow(5);
                    SetAndFormateCell("描述", row5, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["Quantity"], row5, 1, txtStyle);

                    break;
                case "7":
                case "8":
                case "9":
                case "10":
                case "11":
                case "12":
                    row2 = (HSSFRow)sheet.CreateRow(2);
                    SetAndFormateCell("产品名称", row2, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["Name"], row2, 1, txtStyle);
                    //
                    SetAndFormateCell("单价", row2, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["Price"], row2, 3, txtStyle);

                    SetAndFormateCell("联系人", row2, 4, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["ContactPerson"], row2, 5, txtStyle);

                    row3 = (HSSFRow)sheet.CreateRow(3);
                    SetAndFormateCell("联系电话", row3, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["MobileNo"], row3, 1, txtStyle);
                    //
                    SetAndFormateCell("人数", row3, 2, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["Quantity"], row3, 3, txtStyle);

                    SetAndFormateCell("预定时间", row3, 4, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["BookingTime"], row3, 5, dateStyle1);

                    row4 = (HSSFRow)sheet.CreateRow(4);
                    SetAndFormateCell("备注", row4, 0, titleStyle);
                    SetAndFormateCell(drSource, drSource.Table.Columns["Remarks"], row4, 1, txtStyle);
                    break;
            }
            for (int i = 0; i < 6; i++)
            {
                int columnWidth = sheet.GetColumnWidth(i) / 256;
                ICell currentCell = sheet.GetRow(1).GetCell(i);
                int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                if (columnWidth < length)
                {
                    columnWidth = length;
                }
                sheet.SetColumnWidth(i, columnWidth * 256);
            }
            using (var ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                // sheet.Dispose();
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet   
                return ms;
            }
        }

        public static void SetAndFormateCell(string content, HSSFRow dataRow, int columnIndex, HSSFCellStyle style)
        {
            HSSFCell newCell = (HSSFCell)dataRow.CreateCell(columnIndex);
            newCell.SetCellValue(content);
            newCell.CellStyle = style;
        }
        /// <summary>
        /// 根据数据填充单元格
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="newCell"></param>
        public static void SetAndFormateCell(DataRow row, DataColumn column, HSSFRow dataRow, int columnIndex, HSSFCellStyle style)
        {
            HSSFCell newCell = (HSSFCell)dataRow.CreateCell(columnIndex);
            newCell.CellStyle = style;
            string drValue = row[column].ToString();
            switch (column.DataType.ToString())
            {
                case "System.String"://字符串类型   
                    newCell.SetCellValue(drValue);
                    break;
                case "System.DateTime"://日期类型   
                    DateTime dateV;
                    DateTime.TryParse(drValue, out dateV);
                    newCell.SetCellValue(dateV);
                    break;
                case "System.Boolean"://布尔型   
                    bool boolV = false;
                    bool.TryParse(drValue, out boolV);
                    newCell.SetCellValue(boolV ? "是" : "否");
                    break;
                case "System.Int16"://整型   
                case "System.Int32":
                case "System.Int64":
                case "System.Byte":
                    int intV = 0;
                    int.TryParse(drValue, out intV);
                    newCell.SetCellValue(intV);
                    break;
                case "System.Decimal"://浮点型   
                case "System.Double":
                    double doubV = 0;
                    double.TryParse(drValue, out doubV);
                    newCell.SetCellValue(doubV);
                    break;
                case "System.DBNull"://空值处理   
                    newCell.SetCellValue("");
                    break;
                default:
                    newCell.SetCellValue("");
                    break;
            }

        }
        /// <summary>
        /// 构造导出模板
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static DataTable GetRportTemplate(string[] arr)
        {
            DataTable dt = new DataTable();
            foreach (string s in arr)
            {
                dt.Columns.Add(s, typeof(string));
            }
            return dt;
        }
    }
}
