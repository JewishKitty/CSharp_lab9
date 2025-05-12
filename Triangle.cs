using System;

/// <summary>
/// Представляет треугольник с методами для проверки существования, вычисления площади,преобразования типов,
/// а также перегрузкой операторов сравнения и ToString().
/// </summary>
public class Triangle
{
    // Поля
    private double _a;
    private double _b;
    private double _c;

    //Конструкторы
    /// <summary>
    /// Конструктор копирования. Создаёт новый экземпляр треугольника на основе существующего.
    /// </summary>
    /// <param name="original">Исходный треугольник для копирования.</param>
    public Triangle(Triangle original)
    {
        A = original._a;
        B = original._b;
        C = original._c;
    }

    /// <summary>
    /// Основной конструктор. Создаёт треугольник по трём сторонам.
    /// </summary>
    /// <param name="a">Сторона a.</param>
    /// <param name="b">Сторона b.</param>
    /// <param name="c">Сторона c.</param>
    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    //Свойства
    /// <summary>
    /// Длина стороны a. Значение должно быть больше 0.
    /// </summary>
    public double A
    {
        get => _a;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Сторона 'a' должна быть больше нуля.");
            _a = value;
        }
    }

    /// <summary>
    /// Длина стороны b. Значение должно быть больше 0.
    /// </summary>
    public double B
    {
        get => _b;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Сторона 'b' должна быть больше нуля.");
            _b = value;
        }
    }

    /// <summary>
    /// Длина стороны c. Значение должно быть больше 0.
    /// </summary>
    public double C
    {
        get => _c;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Сторона 'c' должна быть больше нуля.");
            _c = value;
        }
    }

    //Методы
    /// <summary>
    /// Проверяет, существует ли треугольник по неравенству треугольника.
    /// </summary>
    /// <returns>true, если треугольник существует; иначе false.</returns>
    public bool DoExist()
    {
        return (_a + _b > _c) && (_a + _c > _b) && (_b + _c > _a);
    }

    /// <summary>
    /// Вычисляет площадь треугольника по формуле Герона.
    /// </summary>
    /// <returns>Площадь треугольника.</returns>
    public double Square()
    {
        double p = (_a + _b + _c) / 2.0;
        return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
    }

    /// <summary>
    /// Неявное преобразование треугольника в double (периметр).
    /// </summary>
    /// <param name="ABC">Экземпляр треугольника.</param>
    public static implicit operator double(Triangle ABC)
    {
        return ABC._a + ABC._b + ABC._c;
    }

    /// <summary>
    /// Явное преобразование треугольника в bool (существует или нет).
    /// </summary>
    /// <param name="ABC">Экземпляр треугольника.</param>
    public static explicit operator bool(Triangle ABC)
    {
        return ABC.DoExist();
    }

    /// <summary>
    /// Сравнивает два треугольника по площади (больше).
    /// </summary>
    public static bool operator >(Triangle ABC, Triangle MKL)
    {
        return ABC.Square() > MKL.Square();
    }

    /// <summary>
    /// Сравнивает два треугольника по площади (меньше).
    /// </summary>
    public static bool operator <(Triangle ABC, Triangle MKL)
    {
        return ABC.Square() < MKL.Square();
    }

    /// <summary>
    /// Возвращает строковое представление треугольника.
    /// </summary>
    /// <returns>Информация о сторонах и существовании треугольника.</returns>
    public override string ToString()
    {
        return $"Длина a: {_a}, Длина b: {_b}, Длина c: {_c}, Существование: {DoExist()}";
    }
}
