using Movies.Service.Models;
using Movies.web.Models;

namespace Movies.web.Extentions
{
    public static class RentInvoiceExtentions
    {
        public static List<RentInvoice> ConvertRentInvoiceModelToModel(this List<RentInvoiceModel> rentInvoiceModels)
        {
            var rentInvoices = rentInvoiceModels.Select(rentInvoice => new RentInvoice()
            {
                Id = rentInvoice.Id,
                RentId = rentInvoice.RentId,
                PaymentId = rentInvoice.PaymentId,
            }).ToList();

            return rentInvoices;
        }

        public static RentInvoice ConvertRentInvoiceToModel(this RentInvoiceModel rentInvoiceModel) {
            return new RentInvoice()
            {
                Id = rentInvoiceModel.Id,
                RentId = rentInvoiceModel.RentId,
                PaymentId = rentInvoiceModel.PaymentId,
            };
        }
    }
}
