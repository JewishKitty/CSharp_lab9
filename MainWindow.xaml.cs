using System;
using System.Windows;


/// <summary>
/// Логика взаимодействия с главным окном приложения.
/// Выполняет ввод данных, проверку существования, вычисление площади и периметра,
/// а также сравнение треугольников
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Конструктор окна
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Преобразует строки в объект <see cref="Triangle"/>, если данные корректны
    /// </summary>
    /// <param name="a">Сторона a</param>
    /// <param name="b">Сторона b</param>
    /// <param name="c">Сторона c</param>
    /// <returns>Экземпляр <see cref="Triangle"/>, если данные валидны, иначе null</returns>
    private Triangle ReadTriangle(string a, string b, string c)
    {
        if (double.TryParse(a, out double da) &&
            double.TryParse(b, out double db) &&
            double.TryParse(c, out double dc) &&
            da > 0 && db > 0 && dc > 0)
        {
            return new Triangle(da, db, dc);
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Обработчик кнопки "Проверить существование".
    /// Выполняет проверку существования треугольника ABC
    /// </summary>
    private void CheckExistence_Click(object sender, RoutedEventArgs e)
    {
        var triangle = ReadTriangle(SideA.Text, SideB.Text, SideC.Text);
        if (triangle == null)
        {
            ResultTextBlock.Text = "Треугольник ABC не введён или длинны сторон отрицательные! Невозможно проверить существование.";
        }
        else
        {
            if ((bool)triangle) ResultTextBlock.Text = "Треугольник существует.";
            else ResultTextBlock.Text = "Треугольник не существует!";
        }
    }

    /// <summary>
    /// Обработчик кнопки "Площадь".
    /// Вычисляет и отображает площадь треугольника ABC
    /// </summary>
    private void CheckSquare_Click(object sender, RoutedEventArgs e)
    {
        var triangle = ReadTriangle(SideA.Text, SideB.Text, SideC.Text);
        if (triangle == null)
        {
            ResultTextBlock.Text = "Треугольник ABC не введён или длинны сторон отрицательные! Невозможно вычислить площадь.";
        }
        else if (!(bool)triangle)
        {
            ResultTextBlock.Text = "Треугольник ABC не существует! Невозможно вычислить площадь.";
        }
        else
        { 
            ResultTextBlock.Text = $"Площадь ABC: {triangle.Square():F2}";
        }
    }

    /// <summary>
    /// Обработчик кнопки "Периметр".
    /// Вычисляет и отображает периметр треугольника ABC
    /// </summary>
    private void CheckPerimeter_Click(object sender, RoutedEventArgs e)
    {
        var triangle = ReadTriangle(SideA.Text, SideB.Text, SideC.Text);
        if (triangle == null)
        {
            ResultTextBlock.Text = "Треугольник ABC не введён или длинны сторон отрицательные! Невозможно вычислить периметр.";
        }
        else if (!(bool)triangle)
        {
            ResultTextBlock.Text = "Треугольник ABC не существует! Невозможно вычислить периметр.";
        }
        else
        {
            double perimeter = triangle; // неявное приведение к double
            ResultTextBlock.Text = $"Периметр ABC: {perimeter:F2}";
        }
    }

    /// <summary>
    /// Обработчик кнопки "Сравнить".
    /// Сравнивает площади треугольников ABC и MKL
    /// </summary>
    private void CompareTriangles_Click(object sender, RoutedEventArgs e)
    {
        var t1 = ReadTriangle(SideA.Text, SideB.Text, SideC.Text);
        var t2 = ReadTriangle(SideM.Text, SideK.Text, SideL.Text);

        if (t1 == null || t2 == null)
        {
            ResultTextBlock.Text = "Ввод треугольников не завершён или длинны сторон отрицательные.";
        }
        else if (!(bool)t1 || !(bool)t2)
        {
            ResultTextBlock.Text = "Как минимум один из треугольников не существует.";
        }
        else
        {
            ResultTextBlock.Text = $"ABC < MKL? {t1 < t2} \nABC > MKL? {t1 > t2}";
        }
    }
}