# iys
IYS (İleti Yönetim Sistemi) .net core 3.1 api client


Bu dokümanda İleti Yönetim Sistemi tarafından sunulan API'nin .net core kütüphanesinin kullanımını görebilirsiniz. IysApiClient altındaki bütün metodlar async/await desteğine sahiptir.

Test Ortamı Erişim Adresi
https://api.sandbox.iys.org.tr
IYS Detaylı api dokümantasyonu için https://apidocs.iys.org.tr/ adresini ziyaret edebilirsiniz.



<b>Nuget üzerinden kurulum yapmak için;</b>
<br>
<br>
Install-Package Internative.IYS.Core -Version 1.0.1
<br>
<b>Kurulum tamamlandıktan sonra;</b>
<br>
IysApiClient nesnesi üzerinden işlemlerinizi yapabilirsiniz. IysApiClient nesnesi static class olup her yerde kullanılabilir.
<br>
<br>
<b>Oturum yönetimi ile ilgili metodlar;</b>
<br>
GetTokenRequest =>  IYS api üzerinden token oluşturma işlemi yapar.
<br>
RefreshTokenRequest => Iys api üzerinden token yenileme işlemini yapar.
<br>
<br>
<b>İzin yönetimi ile ilgili metodlar;</b>
<br>
BulkConstentsRequest => Asenkron toplu izin ekleme işlemi yapar.
<br>
ConsentRequest => Asenkron tekil izin ekleme işlemi yapar.
<br>
ConsentsChangesPullRequest => İzin hareketi sorgulama işlemi yapar.
<br>
ConsentsChangesRequest => Çoklu izin durumu sorgulama işlemi yapar.
<br>
ConsentsChangesStatusRequest => Çoklu izin ekleme isteği sorgulama işlemi yapar.
<br>
ConsentStatusRequest => Tekil izin durumu sorgulama işlemi yapar.
<br>
<br>
<b>Örnek Kullanım;</b>
<br>

```csharp
var result = await IysApiClient.GetTokenRequest(new Core.Models.Request.IysTokenRequest
{
    username = "your-user-name",
    password = "your-password",
    grant_type = "password"
}, "https://api.iys.org.tr/");
```


Diğer detaylar ile ilgili olarak readme dosyasını en kısa sürede güncelleyeceğiz.
