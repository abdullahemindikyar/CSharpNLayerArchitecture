# CSharpNLayerArchitecture

Basit bir N-Layer (katmanlı) mimari örneği. Amaç: Entity, DataAccess, Business ve Presentation katmanlarını kullanarak CRUD yapan küçük bir Windows Forms uygulaması göstermek. Öğrenme amaçlı hazırlandı.

## Özet
- .NET Framework 4.7.2 ile geliştirilmiş.
- Entity sınıfları, Generic Repository, Entity Framework ile DataContext, Business katmanı servisleri ve WinForms arayüzü içerir.
- Kategori ve Ürün (Category, Product) için temel CRUD işlemleri mevcut.

## Gereksinimler
- Visual Studio (19/22/26)
- .NET Framework 4.7.2
- SQL Server (LocalDB veya full SQL) — connectionString App.config içinde ayarlanmalı

## Hızlı kurulum
1. Repo'yu klonla:
   git clone https://github.com/abdullahemindikyar/CSharpNLayerArchitecture.git
2. Visual Studio ile `CSharpNLayerArchitecture.slnx` dosyasını aç.
3. `App.config` içindeki connectionString'i kendi veritabanına göre ayarla.
4. Solution'u Build et (Rebuild).
5. `NLayerArch.PresentationLayer` projesini Startup Project yap ve çalıştır.

## Nasıl kullanılır
- FrmCategory:
  - "Listele" butonuyla tüm kategorileri gör.
  - ID verip "GetById" ile tek kayıt getir.
  - Ekle/Güncelle/Sil işlemleri GUI üzerinden yapılır.
- FrmProduct:
  - Ürün eklemeden önce kategori combobox'ının dolu olduğuna dikkat et (form load sırasında doldurulur).
  - Ürün eklerken comboBox.SelectedValue CategoryId olarak gönderilir.
  - "Listele" ve "Listele 2" ile tüm ürünleri veya kategori bilgisiyle birlikte görebilirsin.

## Proje yapısı (kısaca)
- NLayerArch.EntityLayer: Entity sınıfları (Category, Product, vb.)
- NLayerArch.DataAccessLayer: EF DataContext, GenericRepository, Ef...Dal sınıfları
- NLayerArch.BussinessLayer: Servis arayüzleri ve manager sınıfları
- NLayerArch.PresentationLayer: WinForms ara yüzü (FrmCategory, FrmProduct)

## Notlar
- DataGridView tek bir nesne yerine koleksiyon bekler; tek kayıt göstermek için o nesneyi bir liste içine alıp bind ettim.
- ComboBox doldurma ve SelectedValue kullanımına dikkat et; önceki kodlarda Text üzerinden int.Parse yapıldığında hatalar çıkabiliyordu.
- Eğer GetById her zaman `null` dönüyorsa, girilen ID veritabanında yoktur veya `App.config` içindeki connectionString yanlış veritabanına işaret ediyordur.
