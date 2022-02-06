# Proje Ortamının Oluşturulması 
  - Docker Windows Kurulumu yapıldı  
  - docker run -d --hostname my-rabbit --name myrabbit -e RABBITMQ_DEFAULT_USER=admin -e RABBITMQ_DEFAULT_PASS=123456 -p 5672:5672 -p 15672:15672 rabbitmq:3-management  
  - docker run --name my-postgres -e POSTGRES_PASSWORD=123456 -d -p 5432:5432 postgres  
  - docker run --name pgadmin4 -e PGADMIN_DEFAULT_EMAIL=s.muhammetulas@gmail.com -e PGADMIN_DEFAULT_PASSWORD=123456 -p 5050:80 -d dpage/pgadmin4  
Komutları sayesinde Docker üzerinde çalışan RabbitMQ, PostgreSQL ve bu veri tabanının yönetimi için pgadmin4 kurulumları sağlandı.  
- SonarCloud.io ile github üzerinden master branch'e yapılan her bir değişiklikte otomatik statik kod analizi yapacak yapı oluşturuldu.    
## Proje Hakkında
Proje yapılırken .Net Core 6 kullanılmıştır.  
EF Code First kullanılarak Model nesnelerine göre veri tabanı oluşturulması sağlanmıştır.  
## Notlarım
Daha önce EF kullanan bir projede Unit test yazma tecrübem olmadığı için DBContext nesnesini mocklarken sorun yaşadım. Bu yüzden Service Katmanı Unit Test Kısımları eksiktir. %60 Coverage değerini geçememektedir.  
SonarCloud.io yu da ilk defa denediğim için Exclusion'a eklediğim dosyaları coverage hesaplarken dışlamasını engelleyemedim. Güzel bir araştırmayla öğrenebileceğimi düşünüyorum.  
