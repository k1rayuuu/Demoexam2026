using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exam2026Prism.Context;

public partial class Exam2026Context : DbContext
{
    public Exam2026Context()
    {
    }

    public Exam2026Context(DbContextOptions<Exam2026Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<PickUpPoint> PickUpPoints { get; set; }

    public virtual DbSet<Tovar> Tovars { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-LHUCHHK\\SQLEXPRESS;Database=Exam2026;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_orders");

            entity.Property(e => e.АдресПунктаВыдачи).HasColumnName("Адрес_пункта_выдачи");
            entity.Property(e => e.АртикулЗаказа)
                .HasMaxLength(255)
                .HasColumnName("Артикул_заказа");
            entity.Property(e => e.ДатаДоставки)
                .HasColumnType("datetime")
                .HasColumnName("Дата_доставки");
            entity.Property(e => e.ДатаЗаказа)
                .HasColumnType("datetime")
                .HasColumnName("Дата_заказа");
            entity.Property(e => e.КодДляПолучения).HasColumnName("Код_для_получения");
            entity.Property(e => e.НомерЗаказа).HasColumnName("Номер_заказа");
            entity.Property(e => e.СтатусЗаказа)
                .HasMaxLength(255)
                .HasColumnName("Статус_заказа");
            entity.Property(e => e.ФиоАвторизированногоКлиента)
                .HasMaxLength(255)
                .HasColumnName("ФИО_авторизированного_клиента");
        });

        modelBuilder.Entity<PickUpPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_pickuppoints");

            entity.Property(e => e.Адрес).HasMaxLength(255);
        });

        modelBuilder.Entity<Tovar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tovars");

            entity.Property(e => e.Артикул).HasMaxLength(255);
            entity.Property(e => e.ДействующаяСкидка).HasColumnName("Действующая_скидка");
            entity.Property(e => e.ЕдиницаИзмерения)
                .HasMaxLength(255)
                .HasColumnName("Единица_измерения");
            entity.Property(e => e.КатегорияТовара)
                .HasMaxLength(255)
                .HasColumnName("Категория_товара");
            entity.Property(e => e.КолВоНаСкладе).HasColumnName("Кол_во_на_складе");
            entity.Property(e => e.НаименованиеТовара)
                .HasMaxLength(255)
                .HasColumnName("Наименование_товара");
            entity.Property(e => e.ОписаниеТовара)
                .HasMaxLength(255)
                .HasColumnName("Описание_товара");
            entity.Property(e => e.Поставщик).HasMaxLength(255);
            entity.Property(e => e.Производитель).HasMaxLength(255);
            entity.Property(e => e.Фото).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_users");

            entity.Property(e => e.Логин).HasMaxLength(255);
            entity.Property(e => e.Пароль).HasMaxLength(255);
            entity.Property(e => e.РольСотрудника)
                .HasMaxLength(255)
                .HasColumnName("Роль_сотрудника");
            entity.Property(e => e.Фио)
                .HasMaxLength(255)
                .HasColumnName("ФИО");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
