using System.ComponentModel;

namespace SB.Library.Enum
{
    public enum EnumResultMessage
    {
        [Description("Kayıt İşlemi Başarı İle Gerçekleştirildi.")]
        SaveSuccessful = 0,
        [Description("Güncelleme İşlemi Başarı İle Gerçekleştirildi.")]
        UpdateSuccessful = 1,
        [Description("Silme İşlemi Başarı İle Gerçekleştirildi.")]
        DeleteSuccessful = 2,
        [Description("Sistemsel Bir Hata Oluştu Lütfen Tekrar Deneyiniz.")]
        SystemError = 3,
        [Description("Lütfen Zorunlu Alanları Doldurunuz.")]
        FillInTheRequiredFields = 4,
        [Description("Log Kaydı Yapılamadı. Lütfen Terar Deneyiniz.")]
        LogRecordFailed = 5
    }
}
