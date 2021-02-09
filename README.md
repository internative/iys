# IYS (İleti Yönetim Sistemi) .net core 3.1 api client 
### Bu dokümanda İleti Yönetim Sistemi tarafından sunulan API'nin .net core kütüphanesinin kullanımını görebilirsiniz. IysApiClient altındaki bütün metodlar async/await desteğine sahiptir. 
#### Test Ortamı Erişim Adresi;
https://api.sandbox.iys.org.tr
IYS Detaylı api dokümantasyonu için https://apidocs.iys.org.tr/ adresini ziyaret edebilirsiniz. 
#### Nuget üzerinden kurulum yapmak için;
Install-Package Internative.IYS.Core -Version 1.0.1 
#### Kurulum tamamlandıktan sonra;
IysApiClient nesnesi üzerinden işlemlerinizi yapabilirsiniz. IysApiClient nesnesi static class olup her yerde kullanılabilir. 
#### Oturum yönetimi ile ilgili metodlar;
GetTokenRequest =>  IYS api üzerinden token oluşturma işlemi yapar. 
RefreshTokenRequest => Iys api üzerinden token yenileme işlemini yapar. 
#### İzin yönetimi ile ilgili metodlar;
BulkConstentsRequest => Asenkron toplu izin ekleme işlemi yapar. 
ConsentRequest => Asenkron tekil izin ekleme işlemi yapar. 
ConsentsChangesPullRequest => İzin hareketi sorgulama işlemi yapar. 
ConsentsChangesRequest => Çoklu izin durumu sorgulama işlemi yapar. 
ConsentsChangesStatusRequest => Çoklu izin ekleme isteği sorgulama işlemi yapar. 
ConsentStatusRequest => Tekil izin durumu sorgulama işlemi yapar. 
#### Örnek Kullanım;

```csharp
var result = await IysApiClient.GetTokenRequest(new Core.Models.Request.IysTokenRequest
{
    username = "your-user-name",
    password = "your-password",
    grant_type = "password"
}, "https://api.iys.org.tr/");
```


Diğer detaylar ile ilgili olarak readme dosyasını en kısa sürede güncelleyeceğiz.
