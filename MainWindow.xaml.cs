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
    /// Инициализация окна
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
        var ABC = ReadTriangle(SideA.Text, SideB.Text, SideC.Text);
        if (ABC == null)
        {
            ResultTextBlock.Text = "Треугольник ABC не введён или длинны сторон отрицательные! Невозможно проверить существование.";
        }
        else
        {
            if ((bool)ABC) ResultTextBlock.Text = "Треугольник существует.";
            else ResultTextBlock.Text = "Треугольник не существует!";
        }
    }

    /// <summary>
    /// Обработчик кнопки "Площадь".
    /// Вычисляет и отображает площадь треугольника ABC
    /// </summary>
    private void CheckSquare_Click(object sender, RoutedEventArgs e)
    {
        var ABC = ReadTriangle(SideA.Text, SideB.Text, SideC.Text);
        if (ABC == null)
        {
            ResultTextBlock.Text = "Треугольник ABC не введён или длинны сторон отрицательные! Невозможно вычислить площадь.";
        }
        else if (!(bool)ABC)
        {
            ResultTextBlock.Text = "Треугольник ABC не существует! Невозможно вычислить площадь.";
        }
        else
        { 
            ResultTextBlock.Text = $"Площадь ABC: {ABC.Square():F2}";
        }
    }

    /// <summary>
    /// Обработчик кнопки "Периметр".
    /// Вычисляет и отображает периметр треугольника ABC
    /// </summary>
    private void CheckPerimeter_Click(object sender, RoutedEventArgs e)
    {
        var ABC = ReadTriangle(SideA.Text, SideB.Text, SideC.Text);
        if (ABC == null)
        {
            ResultTextBlock.Text = "Треугольник ABC не введён или длинны сторон отрицательные! Невозможно вычислить периметр.";
        }
        else if (!(bool)ABC)
        {
            ResultTextBlock.Text = "Треугольник ABC не существует! Невозможно вычислить периметр.";
        }
        else
        {
            double perimeter = ABC; // неявное приведение к double
            ResultTextBlock.Text = $"Периметр ABC: {perimeter:F2}";
        }
    }

    /// <summary>
    /// Обработчик кнопки "Сравнить".
    /// Сравнивает площади треугольников ABC и MKL
    /// </summary>
    private void CompareTriangles_Click(object sender, RoutedEventArgs e)
    {
        var ABC = ReadTriangle(SideA.Text, SideB.Text, SideC.Text);
        var MLK = ReadTriangle(SideM.Text, SideK.Text, SideL.Text);

        if (ABC == null || MLK == null)
        {
            ResultTextBlock.Text = "Ввод треугольников не завершён или длинны сторон отрицательные.";
        }
        else if (!(bool)ABC || !(bool)MLK)
        {
            ResultTextBlock.Text = "Как минимум один из треугольников не существует.";
        }
        else
        {
            ResultTextBlock.Text = $"ABC < MKL? {ABC < MLK} \nABC > MKL? {ABC > MLK}";
        }
    }
}
