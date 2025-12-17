# VirusScannerSim
# 🛡️ Antivirüs Tarama Simülasyonu (WinForms)

Bu proje, C# programlama dili kullanılarak geliştirilmiş, dosya sistemi üzerinde sezgisel (heuristic) analizler yaparak şüpheli dosyaları tespit eden bir güvenlik yazılımı simülasyonudur. Uygulama, Nesne Tabanlı Programlama (NTP) prensiplerini ve asenkron veri işleme yöntemlerini temel alır.

## 🌟 Öne Çıkan Özellikler

* **Dinamik UI Yönetimi:** Uygulama arayüzü (butonlar, listeler, ilerleme çubukları) çalışma anında (runtime) kod ile oluşturulur. Bu yaklaşım, arayüz elemanlarının bellekte dinamik olarak yönetilmesini sağlar.
* **Dosya Sistemi Entegrasyonu:** `System.IO` kütüphanesi kullanılarak bilgisayarın fiziksel dizinlerine erişilir ve `FileInfo` sınıfı ile dosya öznitelikleri (isim, uzantı, boyut) analiz edilir.
* **Asenkron Tarama Motoru:** `Task.Delay` ve `async/await` yapısı kullanılarak, tarama işlemi sırasında kullanıcı arayüzünün (UI thread) kilitlenmesi engellenmiştir.
* **Heuristik Tehdit Tespiti:** Dosyalar; uzantı analizleri (örn: .bat, .exe) ve isim kalıpları (örn: "virus" içerenler) üzerinden risk puanlamasına tabi tutulur.

## 🛠 Teknik Mimari

* **Dil:** C#
* **Platform:** .NET Framework / WinForms
* **NTP Konseptleri:** * **Encapsulation:** Dosya bilgilerinin nesne olarak yönetilmesi.
    * **Event-Driven Programming:** Buton tıklama ve dosya tarama olaylarının delegelerle yönetimi.
    * **Dynamic Control Creation:** Form bileşenlerinin nesne örneği (instance) olarak kodla üretilmesi.

## 🚀 Kullanım Adımları

1. **Klasör Seç:** Sistemin taramasını istediğiniz hedef dizini seçin.
2. **Sistemi Tara:** "Sistemi Tara" butonu ile analiz sürecini başlatın
