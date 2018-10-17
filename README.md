# Perseptron (Basit Algılayıcı Modeli) Örnek Çalışması

## Basit Algılayıcı Modeli Nedir?
Perseptron bir sinir hücresinin birden fazla girdiyi alarak bir çıktı üretmesi prensibine dayanmaktadır. Ağın çıktısı bir veya sıfırdan oluşan mantıksal değerdir. Çıktının değerinin hesaplanmasında eşik değer fonksiyonu kullanılır.

## Örnek Kullanımı

```c#
public void Hesaplamalar()
```
Ağ tarafından doğru sınıflandırma oluşana kadar çalışan NetHesaplama fonksiyonun tetiklendiği fonksiyondur.

```c#
public void RandomOlustur()
```
Random olarak Ağırlıkları oluşturma fonksiyonudur.

```c#
public int NetHesaplama(int ornekNo,int iterasyon,double x1, double x2, double w1,double w2, double ogrenme,double beklenen)
```
Net değerinin hesaplandıktan sonra çıktı ve beklenen değer eşleşmesi olmaması durumunda ağırlık değerlerinde değişimlerin yapıldığı fonksiyondur.
