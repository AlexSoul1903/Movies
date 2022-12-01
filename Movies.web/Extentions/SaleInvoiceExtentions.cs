using Movies.Service.Models;
using Movies.web.Models;

namespace Movies.web.Extentions
{
    public static class SaleInvoiceExtentions
    {

        public static List<SaleInvoice> ConvertSaleInvoiceModelToModel(this List<SaleInvoiceModel> saleInvoiceModels)
        {

            var saleInvoices = saleInvoiceModels.Select(saleInvoice => new SaleInvoice()
            {
                Id = saleInvoice.Id,
                SaleId = saleInvoice.SaleId,
                PaymentId = saleInvoice.PaymentId,
            }).ToList();

            return saleInvoices;
        }

        public static SaleInvoice ConvertSaleInvoiceToModel(this SaleInvoiceModel saleInvoiceModel)
        {
            return new SaleInvoice()
            {
                Id = saleInvoiceModel.Id,
                SaleId = saleInvoiceModel.SaleId,
                PaymentId = saleInvoiceModel.PaymentId,
            };
        }
    }
}
