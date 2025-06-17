# StreamProcessorApi (.NET 8)

Bu proje, bir stream (akış) verisini okuyarak hem veritabanına kayıt eden hem de CSV formatında dosyaya dönüştürüp dış servislere (ShareFile ve SFTP) gönderen .NET 8 tabanlı bir Web API uygulamasıdır.

---

## 🚀 Özellikler

✅ Gelen veriyi `FirstName,LastName,Email` formatında satır satır parse eder  
✅ EF Core ile MS SQL Server’a kayıt işlemi yapar  
✅ Aynı veriden bir CSV dosyası oluşturur (`wwwroot/files/` klasörüne)  
✅ CSV dosyasını ShareFile API ve SFTP'ye gönderir *(mock servislerle)*  
✅ Katmanlı mimari ve SOLID prensipleriyle yazılmıştır  
✅ Hız ve performans odaklı tasarlanmıştır  

---

## 🛠️ Kullanılan Teknolojiler

- ASP.NET Core 8 Web API
- Entity Framework Core
- MS SQL Server
- Bogus (dummy veri üretimi için)
- ShareFile ve SFTP servisleri (mock servis)
- StreamReader & FileWriter
- SOLID & Clean Code

---

## ⚙️ Kurulum

### 1. Repository’i Klonla

```bash
git clone https://github.com/enescivelek/StreamProcessorApi.git
cd StreamProcessorApi
