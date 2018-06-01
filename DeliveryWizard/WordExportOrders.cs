using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using DeliveryWizard;

namespace DeliveryWizard
{    
    public class WordExportOrders
    {
       private static Word.Application wdApp = new Microsoft.Office.Interop.Word.Application();

       public static void WordExport(DeliveryRquestDto dto)
        {
            wdApp.Documents.Add();
            Word.Document doc = wdApp.Documents[1];            
            wdApp.Selection.TypeText("ФИО получателя: " + dto.FullName);
            wdApp.Selection.TypeText("\nАдрес доставкиЖ " + dto.ClientAddress);
            wdApp.Selection.TypeText("\nДата и время заполнения: " + dto.Filled);
            wdApp.Selection.TypeText("\nВремя доставки: " + dto.TimeDeliver);
            wdApp.Selection.TypeText("\nСтатус заказа: " + dto.State);
            wdApp.Selection.TypeText("\nМеста покупок:");
            foreach (var e in dto.WayPoints)
            {                
                wdApp.Selection.TypeText("\nНазвание места: " + e.PlaceTitle);
                wdApp.Selection.TypeText("\nАдрес места: " + e.Address);
                wdApp.Selection.TypeText("\nТип места: " + e.ShopType);
                wdApp.Selection.TypeText("\nСписок продуктов\n");
                var range = wdApp.Selection.Range;
                var wdTable = doc.Tables.Add(range, e.ProductsList.Count + 1, 4);
                wdTable.Borders.Enable = 1;
                wdTable.Cell(1, 1).Range.Text = "Название продукта";
                wdTable.Cell(1, 2).Range.Text = "Количество";
                wdTable.Cell(1, 3).Range.Text = "Дополнительная информация";
                wdTable.Cell(1, 4).Range.Text = "Цена продукта";
                foreach (var p in e.ProductsList)
                {
                    for (int i = 2; i <= e.ProductsList.Count+1; i++)
                    {
                        wdTable.Cell(i, 1).Range.Text = p.Name;
                        wdTable.Cell(i, 2).Range.Text = p.Amount.ToString();
                        wdTable.Cell(i, 3).Range.Text = p.Additions;
                        wdTable.Cell(i, 4).Range.Text = p.Cost.ToString();
                    }
                }
                wdTable.Range.Paragraphs.Last.Next().Range.Select();
                wdApp.Selection.Collapse(Word.WdCollapseDirection.wdCollapseStart);
                wdApp.Selection.TypeText("Общая стоимость покупок в этом месте: " + e.TotalCost);
            }            
            wdApp.Selection.TypeText("\nОбщая стоимость заказа: " + dto.TotalCost);

            wdApp.Visible = true;
            wdApp = new Word.Application();            
        }
    }
}
