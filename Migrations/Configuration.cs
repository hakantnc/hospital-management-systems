namespace HospitalSystem.Migrations
{
    using HospitalSystem.Helpers;
    using HospitalSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HospitalSystem.Data.HospitalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HospitalSystem.Data.HospitalContext context)
        {
         //DEPARTMANLAR
            context.Departments.AddOrUpdate(d => d.DepartmentID,
                new Department { DepartmentID = 1, DepartmentName = "Dahiliye", Description = "İç hastalıkları bölümü" },
                new Department { DepartmentID = 2, DepartmentName = "Kardiyoloji", Description = "Kalp ve damar hastalıkları" },
                new Department { DepartmentID = 3, DepartmentName = "Ortopedi", Description = "Kemik ve eklem hastalıkları" },
                new Department { DepartmentID = 4, DepartmentName = "Nöroloji", Description = "Sinir sistemi hastalıkları" },
                new Department { DepartmentID = 5, DepartmentName = "Göz Hastalıkları", Description = "Göz sağlığı ve cerrahisi" },
                new Department { DepartmentID = 6, DepartmentName = "Kulak Burun Boğaz", Description = "KBB hastalıkları" },
                new Department { DepartmentID = 7, DepartmentName = "Dermatoloji", Description = "Cilt hastalıkları" },
                new Department { DepartmentID = 8, DepartmentName = "Üroloji", Description = "İdrar yolları hastalıkları" },
                new Department { DepartmentID = 9, DepartmentName = "Genel Cerrahi", Description = "Cerrahi müdahaleler" },
                new Department { DepartmentID = 10, DepartmentName = "Pediatri", Description = "Çocuk sağlığı ve hastalıkları" }
            );
            context.SaveChanges();

        //ADMIN KULLANICISI
            context.Users.AddOrUpdate(u => u.Email,
                new User
                {
                    UserID = 1,
                    FirstName = "Admin",
                    LastName = "Yönetici",
                    Email = "admin@hospital.com",
                    PasswordHash = PasswordHelper.ComputeSha256Hash("Admin123"),
                    Role = "Admin",
                    TCKN = "10000000001",
                    Phone = "05301000001",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1980, 1, 15),
                    CreatedAt = DateTime.Now
                }
            );
            context.SaveChanges();

        //DOKTOR KULLANICILARI
            context.Users.AddOrUpdate(u => u.Email,
                // Doktor 1 - Dahiliye
                new User
                {
                    UserID = 2,
                    FirstName = "Ahmet",
                    LastName = "Yılmaz",
                    Email = "ahmet.yilmaz@hospital.com",
                    PasswordHash = PasswordHelper.ComputeSha256Hash("Doctor123"),
                    Role = "Doctor",
                    TCKN = "20000000001",
                    Phone = "05302000001",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1975, 3, 20),
                    CreatedAt = DateTime.Now
                },
                // Doktor 2 - Kardiyoloji
                new User
                {
                    UserID = 3,
                    FirstName = "Ayşe",
                    LastName = "Demir",
                    Email = "ayse.demir@hospital.com",
                    PasswordHash = PasswordHelper.ComputeSha256Hash("Doctor123"),
                    Role = "Doctor",
                    TCKN = "20000000002",
                    Phone = "05302000002",
                    Gender = "Kadın",
                    DateOfBirth = new DateTime(1980, 7, 10),
                    CreatedAt = DateTime.Now
                },
                // Doktor 3 - Ortopedi
                new User
                {
                    UserID = 4,
                    FirstName = "Mehmet",
                    LastName = "Kaya",
                    Email = "mehmet.kaya@hospital.com",
                    PasswordHash = PasswordHelper.ComputeSha256Hash("Doctor123"),
                    Role = "Doctor",
                    TCKN = "20000000003",
                    Phone = "05302000003",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1978, 11, 5),
                    CreatedAt = DateTime.Now
                },
                // Doktor 4 - Nöroloji
                new User
                {
                    UserID = 5,
                    FirstName = "Fatma",
                    LastName = "Öztürk",
                    Email = "fatma.ozturk@hospital.com",
                    PasswordHash = PasswordHelper.ComputeSha256Hash("Doctor123"),
                    Role = "Doctor",
                    TCKN = "20000000004",
                    Phone = "05302000004",
                    Gender = "Kadın",
                    DateOfBirth = new DateTime(1982, 4, 25),
                    CreatedAt = DateTime.Now
                },
                // Doktor 5 - Göz Hastalıkları
                new User
                {
                    UserID = 6,
                    FirstName = "Ali",
                    LastName = "Çelik",
                    Email = "ali.celik@hospital.com",
                    PasswordHash = PasswordHelper.ComputeSha256Hash("Doctor123"),
                    Role = "Doctor",
                    TCKN = "20000000005",
                    Phone = "05302000005",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1976, 9, 12),
                    CreatedAt = DateTime.Now
                },
                // Doktor 6 - KBB
                new User
                {
                    UserID = 7,
                    FirstName = "Zeynep",
                    LastName = "Arslan",
                    Email = "zeynep.arslan@hospital.com",
                    PasswordHash = PasswordHelper.ComputeSha256Hash("Doctor123"),
                    Role = "Doctor",
                    TCKN = "20000000006",
                    Phone = "05302000006",
                    Gender = "Kadın",
                    DateOfBirth = new DateTime(1984, 2, 18),
                    CreatedAt = DateTime.Now
                },
                // Doktor 7 - Dermatoloji
                new User
                {
                    UserID = 8,
                    FirstName = "Mustafa",
                    LastName = "Şahin",
                    Email = "mustafa.sahin@hospital.com",
                    PasswordHash = PasswordHelper.ComputeSha256Hash("Doctor123"),
                    Role = "Doctor",
                    TCKN = "20000000007",
                    Phone = "05302000007",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1979, 6, 30),
                    CreatedAt = DateTime.Now
                },
                // Doktor 8 - Üroloji
                new User
                {
                    UserID = 9,
                    FirstName = "Elif",
                    LastName = "Yıldız",
                    Email = "elif.yildiz@hospital.com",
                    PasswordHash = PasswordHelper.ComputeSha256Hash("Doctor123"),
                    Role = "Doctor",
                    TCKN = "20000000008",
                    Phone = "05302000008",
                    Gender = "Kadın",
                    DateOfBirth = new DateTime(1981, 12, 8),
                    CreatedAt = DateTime.Now
                },
                // Doktor 9 - Genel Cerrahi
                new User
                {
                    UserID = 10,
                    FirstName = "Hasan",
                    LastName = "Aydın",
                    Email = "hasan.aydin@hospital.com",
                    PasswordHash = PasswordHelper.ComputeSha256Hash("Doctor123"),
                    Role = "Doctor",
                    TCKN = "20000000009",
                    Phone = "05302000009",
                    Gender = "Erkek",
                    DateOfBirth = new DateTime(1973, 8, 22),
                    CreatedAt = DateTime.Now
                },
                // Doktor 10 - Pediatri
                new User
                {
                    UserID = 11,
                    FirstName = "Selin",
                    LastName = "Koç",
                    Email = "selin.koc@hospital.com",
                    PasswordHash = PasswordHelper.ComputeSha256Hash("Doctor123"),
                    Role = "Doctor",
                    TCKN = "20000000010",
                    Phone = "05302000010",
                    Gender = "Kadın",
                    DateOfBirth = new DateTime(1985, 5, 14),
                    CreatedAt = DateTime.Now
                }
            );
            context.SaveChanges();

        //HASTA KULLANICILARI
            context.Users.AddOrUpdate(u => u.Email,
                new User { UserID = 12, FirstName = "Emre", LastName = "Aksoy", Email = "emre.aksoy@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000001", Phone = "05303000001", Gender = "Erkek", DateOfBirth = new DateTime(1990, 1, 5), CreatedAt = DateTime.Now },
                new User { UserID = 13, FirstName = "Deniz", LastName = "Korkmaz", Email = "deniz.korkmaz@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000002", Phone = "05303000002", Gender = "Kadın", DateOfBirth = new DateTime(1988, 3, 12), CreatedAt = DateTime.Now },
                new User { UserID = 14, FirstName = "Burak", LastName = "Özdemir", Email = "burak.ozdemir@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000003", Phone = "05303000003", Gender = "Erkek", DateOfBirth = new DateTime(1995, 7, 20), CreatedAt = DateTime.Now },
                new User { UserID = 15, FirstName = "Ceren", LastName = "Yılmaz", Email = "ceren.yilmaz@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000004", Phone = "05303000004", Gender = "Kadın", DateOfBirth = new DateTime(1992, 11, 8), CreatedAt = DateTime.Now },
                new User { UserID = 16, FirstName = "Oğuz", LastName = "Kara", Email = "oguz.kara@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000005", Phone = "05303000005", Gender = "Erkek", DateOfBirth = new DateTime(1985, 4, 15), CreatedAt = DateTime.Now },
                new User { UserID = 17, FirstName = "Seda", LastName = "Güneş", Email = "seda.gunes@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000006", Phone = "05303000006", Gender = "Kadın", DateOfBirth = new DateTime(1998, 9, 3), CreatedAt = DateTime.Now },
                new User { UserID = 18, FirstName = "Kaan", LastName = "Erdoğan", Email = "kaan.erdogan@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000007", Phone = "05303000007", Gender = "Erkek", DateOfBirth = new DateTime(1982, 6, 28), CreatedAt = DateTime.Now },
                new User { UserID = 19, FirstName = "İrem", LastName = "Çetin", Email = "irem.cetin@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000008", Phone = "05303000008", Gender = "Kadın", DateOfBirth = new DateTime(1993, 2, 17), CreatedAt = DateTime.Now },
                new User { UserID = 20, FirstName = "Serkan", LastName = "Polat", Email = "serkan.polat@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000009", Phone = "05303000009", Gender = "Erkek", DateOfBirth = new DateTime(1978, 10, 11), CreatedAt = DateTime.Now },
                new User { UserID = 21, FirstName = "Gizem", LastName = "Aktaş", Email = "gizem.aktas@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000010", Phone = "05303000010", Gender = "Kadın", DateOfBirth = new DateTime(1996, 8, 25), CreatedAt = DateTime.Now },
                new User { UserID = 22, FirstName = "Tolga", LastName = "Demirci", Email = "tolga.demirci@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000011", Phone = "05303000011", Gender = "Erkek", DateOfBirth = new DateTime(1987, 12, 1), CreatedAt = DateTime.Now },
                new User { UserID = 23, FirstName = "Melis", LastName = "Sarı", Email = "melis.sari@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000012", Phone = "05303000012", Gender = "Kadın", DateOfBirth = new DateTime(1991, 5, 19), CreatedAt = DateTime.Now },
                new User { UserID = 24, FirstName = "Onur", LastName = "Yalçın", Email = "onur.yalcin@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000013", Phone = "05303000013", Gender = "Erkek", DateOfBirth = new DateTime(1983, 3, 7), CreatedAt = DateTime.Now },
                new User { UserID = 25, FirstName = "Başak", LastName = "Tuncer", Email = "basak.tuncer@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000014", Phone = "05303000014", Gender = "Kadın", DateOfBirth = new DateTime(1994, 7, 30), CreatedAt = DateTime.Now },
                new User { UserID = 26, FirstName = "Cem", LastName = "Özkan", Email = "cem.ozkan@gmail.com", PasswordHash = PasswordHelper.ComputeSha256Hash("Patient123"), Role = "Patient", TCKN = "30000000015", Phone = "05303000015", Gender = "Erkek", DateOfBirth = new DateTime(1989, 11, 22), CreatedAt = DateTime.Now }
            );
            context.SaveChanges();

        //DOKTOR PROFİLLERİ
            context.Doctors.AddOrUpdate(d => d.UserID,
                new Doctor { UserID = 2, DepartmentID = 1, Specialization = "İç Hastalıkları Uzmanı", LicenseNumber = "DR-2024-001", Biography = "15 yıllık deneyimli dahiliye uzmanı" },
                new Doctor { UserID = 3, DepartmentID = 2, Specialization = "Kardiyoloji Uzmanı", LicenseNumber = "DR-2024-002", Biography = "Kalp ve damar cerrahisi konusunda uzman" },
                new Doctor { UserID = 4, DepartmentID = 3, Specialization = "Ortopedi Uzmanı", LicenseNumber = "DR-2024-003", Biography = "Spor yaralanmaları ve eklem cerrahisi" },
                new Doctor { UserID = 5, DepartmentID = 4, Specialization = "Nöroloji Uzmanı", LicenseNumber = "DR-2024-004", Biography = "Baş ağrısı ve sinir sistemi hastalıkları" },
                new Doctor { UserID = 6, DepartmentID = 5, Specialization = "Göz Hastalıkları Uzmanı", LicenseNumber = "DR-2024-005", Biography = "Katarakt ve lazer tedavisi" },
                new Doctor { UserID = 7, DepartmentID = 6, Specialization = "KBB Uzmanı", LicenseNumber = "DR-2024-006", Biography = "Kulak burun boğaz cerrahisi" },
                new Doctor { UserID = 8, DepartmentID = 7, Specialization = "Dermatoloji Uzmanı", LicenseNumber = "DR-2024-007", Biography = "Cilt hastalıkları ve estetik dermatoloji" },
                new Doctor { UserID = 9, DepartmentID = 8, Specialization = "Üroloji Uzmanı", LicenseNumber = "DR-2024-008", Biography = "İdrar yolları ve böbrek hastalıkları" },
                new Doctor { UserID = 10, DepartmentID = 9, Specialization = "Genel Cerrahi Uzmanı", LicenseNumber = "DR-2024-009", Biography = "Laparoskopik cerrahi uzmanı" },
                new Doctor { UserID = 11, DepartmentID = 10, Specialization = "Çocuk Sağlığı Uzmanı", LicenseNumber = "DR-2024-010", Biography = "Bebek ve çocuk hastalıkları" }
            );
            context.SaveChanges();

        //HASTA PROFİLLERİ
            context.Patients.AddOrUpdate(p => p.UserID,
                new Patient { UserID = 12, Address = "Kadıköy, İstanbul" },
                new Patient { UserID = 13, Address = "Beşiktaş, İstanbul" },
                new Patient { UserID = 14, Address = "Üsküdar, İstanbul" },
                new Patient { UserID = 15, Address = "Bakırköy, İstanbul" },
                new Patient { UserID = 16, Address = "Şişli, İstanbul" },
                new Patient { UserID = 17, Address = "Maltepe, İstanbul" },
                new Patient { UserID = 18, Address = "Ataşehir, İstanbul" },
                new Patient { UserID = 19, Address = "Pendik, İstanbul" },
                new Patient { UserID = 20, Address = "Kartal, İstanbul" },
                new Patient { UserID = 21, Address = "Sarıyer, İstanbul" },
                new Patient { UserID = 22, Address = "Beyoğlu, İstanbul" },
                new Patient { UserID = 23, Address = "Fatih, İstanbul" },
                new Patient { UserID = 24, Address = "Zeytinburnu, İstanbul" },
                new Patient { UserID = 25, Address = "Bağcılar, İstanbul" },
                new Patient { UserID = 26, Address = "Esenler, İstanbul" }
            );
            context.SaveChanges();

            // ==================== ÖRNEK RANDEVULAR (Her hasta için en az 1 randevu) ====================
            // Doktor UserID'leri: 2-11 | Hasta UserID'leri: 12-26
            context.Appointments.AddOrUpdate(a => a.AppointmentID,
                // Hasta 12 - (UserID=12)
                new Appointment { AppointmentID = 1, PatientID = 12, DoctorID = 2, AppointmentDateTime = DateTime.Now.AddDays(2).AddHours(9), Status = "Aktif", Reason = "Genel kontrol" },
                new Appointment { AppointmentID = 2, PatientID = 12, DoctorID = 3, AppointmentDateTime = DateTime.Now.AddDays(-5).AddHours(10), Status = "Tamamlandı", Reason = "Kalp çarpıntısı" },
                
                // Hasta 13 - (UserID=13)
                new Appointment { AppointmentID = 3, PatientID = 13, DoctorID = 4, AppointmentDateTime = DateTime.Now.AddDays(3).AddHours(10), Status = "Aktif", Reason = "Göğüs ağrısı" },
                new Appointment { AppointmentID = 4, PatientID = 13, DoctorID = 5, AppointmentDateTime = DateTime.Now.AddDays(-3).AddHours(14), Status = "Tamamlandı", Reason = "Baş dönmesi" },
                
                // Hasta 14 - (UserID=14)
                new Appointment { AppointmentID = 5, PatientID = 14, DoctorID = 4, AppointmentDateTime = DateTime.Now.AddDays(1).AddHours(14), Status = "Aktif", Reason = "Diz ağrısı" },
                new Appointment { AppointmentID = 6, PatientID = 14, DoctorID = 6, AppointmentDateTime = DateTime.Now.AddDays(-7).AddHours(11), Status = "Tamamlandı", Reason = "Bel ağrısı" },
                
                // Hasta 15 - (UserID=15)
                new Appointment { AppointmentID = 7, PatientID = 15, DoctorID = 5, AppointmentDateTime = DateTime.Now.AddDays(4).AddHours(11), Status = "Aktif", Reason = "Baş ağrısı" },
                new Appointment { AppointmentID = 8, PatientID = 15, DoctorID = 8, AppointmentDateTime = DateTime.Now.AddDays(-10).AddHours(15), Status = "Tamamlandı", Reason = "Uyku bozukluğu" },
                
                // Hasta 16 - (UserID=16)
                new Appointment { AppointmentID = 9, PatientID = 16, DoctorID = 6, AppointmentDateTime = DateTime.Now.AddDays(-1).AddHours(9), Status = "Tamamlandı", Reason = "Görme problemi" },
                new Appointment { AppointmentID = 10, PatientID = 16, DoctorID = 6, AppointmentDateTime = DateTime.Now.AddDays(7).AddHours(10), Status = "Aktif", Reason = "Göz kontrolü" },
                
                // Hasta 17 - (UserID=17)
                new Appointment { AppointmentID = 11, PatientID = 17, DoctorID = 7, AppointmentDateTime = DateTime.Now.AddDays(5).AddHours(15), Status = "Aktif", Reason = "Kulak ağrısı" },
                new Appointment { AppointmentID = 12, PatientID = 17, DoctorID = 7, AppointmentDateTime = DateTime.Now.AddDays(-4).AddHours(9), Status = "Tamamlandı", Reason = "Boğaz enfeksiyonu" },
                
                // Hasta 18 - (UserID=18)
                new Appointment { AppointmentID = 13, PatientID = 18, DoctorID = 8, AppointmentDateTime = DateTime.Now.AddDays(2).AddHours(11), Status = "Aktif", Reason = "Cilt döküntüsü" },
                new Appointment { AppointmentID = 14, PatientID = 18, DoctorID = 8, AppointmentDateTime = DateTime.Now.AddDays(-6).AddHours(14), Status = "Tamamlandı", Reason = "Alerji testi" },
                
                // Hasta 19 - (UserID=19)
                new Appointment { AppointmentID = 15, PatientID = 19, DoctorID = 11, AppointmentDateTime = DateTime.Now.AddDays(3).AddHours(16), Status = "Aktif", Reason = "Çocuk kontrolü" },
                new Appointment { AppointmentID = 16, PatientID = 19, DoctorID = 11, AppointmentDateTime = DateTime.Now.AddDays(-8).AddHours(10), Status = "Tamamlandı", Reason = "Aşı kontrolü" },
                
                // Hasta 20 - (UserID=20)
                new Appointment { AppointmentID = 17, PatientID = 20, DoctorID = 10, AppointmentDateTime = DateTime.Now.AddDays(-2).AddHours(10), Status = "Tamamlandı", Reason = "Ameliyat sonrası kontrol" },
                new Appointment { AppointmentID = 18, PatientID = 20, DoctorID = 10, AppointmentDateTime = DateTime.Now.AddDays(8).AddHours(9), Status = "Aktif", Reason = "Kontrol muayenesi" },
                
                // Hasta 21 - (UserID=21)
                new Appointment { AppointmentID = 19, PatientID = 21, DoctorID = 9, AppointmentDateTime = DateTime.Now.AddDays(6).AddHours(14), Status = "Aktif", Reason = "Rutin kontrol" },
                new Appointment { AppointmentID = 20, PatientID = 21, DoctorID = 9, AppointmentDateTime = DateTime.Now.AddDays(-12).AddHours(11), Status = "Tamamlandı", Reason = "Tahlil sonucu" },
                
                // Hasta 22 - (UserID=22)
                new Appointment { AppointmentID = 21, PatientID = 22, DoctorID = 2, AppointmentDateTime = DateTime.Now.AddDays(4).AddHours(9), Status = "Aktif", Reason = "Grip belirtileri" },
                new Appointment { AppointmentID = 22, PatientID = 22, DoctorID = 3, AppointmentDateTime = DateTime.Now.AddDays(-15).AddHours(15), Status = "Tamamlandı", Reason = "Şeker testi" },
                
                // Hasta 23 - (UserID=23)
                new Appointment { AppointmentID = 23, PatientID = 23, DoctorID = 3, AppointmentDateTime = DateTime.Now.AddDays(9).AddHours(10), Status = "Aktif", Reason = "Kalp kontrolü" },
                new Appointment { AppointmentID = 24, PatientID = 23, DoctorID = 4, AppointmentDateTime = DateTime.Now.AddDays(-9).AddHours(14), Status = "Tamamlandı", Reason = "EKG çekimi" },
                
                // Hasta 24 - (UserID=24)
                new Appointment { AppointmentID = 25, PatientID = 24, DoctorID = 4, AppointmentDateTime = DateTime.Now.AddDays(10).AddHours(11), Status = "Aktif", Reason = "Omuz ağrısı" },
                new Appointment { AppointmentID = 26, PatientID = 24, DoctorID = 5, AppointmentDateTime = DateTime.Now.AddDays(-20).AddHours(9), Status = "Tamamlandı", Reason = "MR sonucu" },
                
                // Hasta 25 - (UserID=25)
                new Appointment { AppointmentID = 27, PatientID = 25, DoctorID = 8, AppointmentDateTime = DateTime.Now.AddDays(5).AddHours(16), Status = "Aktif", Reason = "Sivilce tedavisi" },
                new Appointment { AppointmentID = 28, PatientID = 25, DoctorID = 8, AppointmentDateTime = DateTime.Now.AddDays(-11).AddHours(10), Status = "Tamamlandı", Reason = "Cilt bakımı" },
                
                // Hasta 26 - (UserID=26)
                new Appointment { AppointmentID = 29, PatientID = 26, DoctorID = 7, AppointmentDateTime = DateTime.Now.AddDays(7).AddHours(13), Status = "Aktif", Reason = "İşitme testi" },
                new Appointment { AppointmentID = 30, PatientID = 26, DoctorID = 7, AppointmentDateTime = DateTime.Now.AddDays(-14).AddHours(11), Status = "Tamamlandı", Reason = "Sinüzit tedavisi" }
            );
            context.SaveChanges();
        }
    }
}
