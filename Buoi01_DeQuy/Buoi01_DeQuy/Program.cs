using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=== Bài 1: Tính S(n) = 1 + 2 + 3 + ... + (n-1) + n ===");
Bai1();

Console.WriteLine("\n=== Bài 2: Tính S(n) = 1 + 2^2 + 3^2 + ... + (n-1)^2 + n^2 ===");
Bai2();

Console.WriteLine("\n=== Bài 3: Tính S(n) = 1 + 1/2 + 1/3 + ... + 1/(n-1) + 1/n ===");
Bai3();

Console.WriteLine("\n=== Bài 4: Tính S(x, n) = x^n ===");
Bai4();

Console.WriteLine("\n=== Bài 5: Tìm ước số lẻ lớn nhất của số nguyên dương n ===");
Bai5();

Console.WriteLine("\n=== Bài 6: Tìm ước chung lớn nhất của 2 số nguyên dương a, b ===");
Bai6();

Console.WriteLine("\n=== Bài 7: Đếm số chữ số của số nguyên dương n ===");
Bai7();

Console.WriteLine("\n=== Bài 8: Tính tổng căn lồng nhau S(n) ===");
Bai8();

// ---------------------------------------------------------
// CHI TIẾT CÁC BÀI TOÁN
// ---------------------------------------------------------

// --- BÀI TẬP 1 ---
static void Bai1()
{
    Console.Write("Nhập số nguyên dương n (n >= 1): ");
    int n = int.Parse(Console.ReadLine()!);

    if (n >= 1)
        Console.WriteLine($"Kết quả S({n}) = {TinhTongBai1(n)}");
    else
        Console.WriteLine("n phải >= 1");
}

static int TinhTongBai1(int n)
{
    if (n == 1)
        return 1;
    return TinhTongBai1(n - 1) + n;
}

// --- BÀI TẬP 2 ---
static void Bai2()
{
    Console.Write("Nhập số nguyên dương n (n >= 1): ");
    int n = int.Parse(Console.ReadLine()!);

    if (n >= 1)
        Console.WriteLine($"Kết quả S({n}) = {TinhTongBinhPhuongBai2(n)}");
    else
        Console.WriteLine("n phải >= 1");
}

static long TinhTongBinhPhuongBai2(int n)
{
    if (n == 1)
        return 1;
    return TinhTongBinhPhuongBai2(n - 1) + (long)n * n;
}

// --- BÀI TẬP 3 ---
static void Bai3()
{
    Console.Write("Nhập số nguyên dương n (n >= 1): ");
    int n = int.Parse(Console.ReadLine()!);

    if (n >= 1)
        Console.WriteLine($"Kết quả S({n}) = {TinhTongPhanSoBai3(n)}");
    else
        Console.WriteLine("n phải >= 1");
}

static double TinhTongPhanSoBai3(int n)
{
    if (n == 1)
        return 1.0;
    return TinhTongPhanSoBai3(n - 1) + 1.0 / n;
}

// --- BÀI TẬP 4 ---
static void Bai4()
{
    Console.Write("Nhập cơ số thực x: ");
    double x = double.Parse(Console.ReadLine()!);

    Console.Write("Nhập số mũ nguyên n: ");
    int n = int.Parse(Console.ReadLine()!);

    Console.WriteLine($"Kết quả S({x}, {n}) = {SBai4(x, n)}");
}

static double LuyThua(double x, int n)
{
    if (n == 0)
        return 1.0;
    return LuyThua(x, n - 1) * x;
}

static double SBai4(double x, int n)
{
    if (n < 0)
        return 1.0 / LuyThua(x, -n);
    else
        return LuyThua(x, n);
}

// --- BÀI TẬP 5 ---
static void Bai5()
{
    Console.Write("Nhập số nguyên dương n: ");
    int n = int.Parse(Console.ReadLine()!);

    if (n > 0)
        Console.WriteLine($"Ước số lẻ lớn nhất của {n} là: {UocLeMax(n)}");
    else
        Console.WriteLine("n phải > 0");
}

static int UocLeMax(int n)
{
    if (n % 2 == 1)
        return n;
    return UocLeMax(n / 2);
}

// --- BÀI TẬP 6 ---
static void Bai6()
{
    Console.Write("Nhập số nguyên dương a: ");
    int a = int.Parse(Console.ReadLine()!);

    Console.Write("Nhập số nguyên dương b: ");
    int b = int.Parse(Console.ReadLine()!);

    if (a > 0 && b > 0)
        Console.WriteLine($"UCLN({a}, {b}) = {UCLN(a, b)}");
    else
        Console.WriteLine("a và b phải > 0");
}

static int UCLN(int a, int b)
{
    if (a % b == 0)
        return b;
    return UCLN(b, a % b);
}

// --- BÀI TẬP 7 ---
static void Bai7()
{
    Console.Write("Nhập số nguyên dương n: ");
    int n = int.Parse(Console.ReadLine()!);

    if (n > 0)
        Console.WriteLine($"Số chữ số của {n} là: {SoChuSo(n)}");
    else
        Console.WriteLine("n phải > 0");
}

static int SoChuSo(int n)
{
    if (n == 0)
        return 0;
    return SoChuSo(n / 10) + 1;
}

// --- BÀI TẬP 8 ---
static void Bai8()
{
    Console.Write("Nhập số nguyên dương n (n >= 1): ");
    int n = int.Parse(Console.ReadLine()!);

    if (n >= 1)
        Console.WriteLine($"Kết quả S({n}) = {SBai8(n)}");
    else
        Console.WriteLine("n phải >= 1");
}

static float Can(int i, int n)
{
    if (i == n)
        return (float)Math.Sqrt(n);
    else
        return (float)Math.Sqrt(i + Can(i + 1, n));
}

static float SBai8(int n)
{
    return Can(1, n);
}