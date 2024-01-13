# Unity Çalışmaları

Bu repoda unity öğrenirken ki çalışmalara yer vermekteyim.

- **Running Fighter :** Bu örnekte 2D platformda sağa sola koşturup zıplayan bir karatecinin kullanımı söz konusu. Grafik nesnelerin bir sprite ile ilişkilendirilmesi, bir animasyonu oluşturan sprite sheet'lerin hareketlere bağlı olarak ayarlanması, aminasyon serilerinin uygulanması, karakter hareketleri için klavyeden alınan komutlara göre kod tarafında düzenlemeler yapılması gibi konuları öğrendim. Son eklemelerle birlikte karakterin sonsuza kadar değil bir sefer zıplaması, yürüme ve koşma işlevselliklerinin ayrılması ve duvarlara denk geldiğinde yapışmadan hemen aşağıya inmesi _(Pyhsics Material kullanılarak)_ gibi düzeltmeler yapıldı. Ardından combo attack opsiyonu da eklendi. Unity ile ilk kez ilgilenen birisi olduğumdam designer ve script arasındaki ilişkide bir süre sonra zorlandığımı hissettim. Örneğin şu anki senaryoda zıpladığımızda saldırı tuşuna basarsam aşağıya inme süresi yavaşlıyor. Ayrıca sağa doğru atak yaparken bazı durumlarda Flip fonksiyonu devreye girip dövüşçü sol tarafa dönüveriyor :D Şu an için öğrenim modunda olduğumdan çok fazla takılmıyorum.

Oyunun tuş kombinasyonları şöyle.

- **A(Attack) :** 3 farklı atak animasyonu var. Hızlı basılırsa combo atack oluyor. Soğuma süresi de var. Sürekli Combo yapılamıyor.
- **Space  :** Zıplama _(Bug var. Zıpladıktan sonra Attack tuşuna basılırsa iniş yavaşlıyor)_
- **S(Dash Speed) :** Koşmayı sağlayan tuş. Belli bir süre koşabiliyor sonra soğuyana kadar sadece yürüyebiliyor.

![Screenshots/running_fighter.gif](Screenshots/running_fighter.gif)