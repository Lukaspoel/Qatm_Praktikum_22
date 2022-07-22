using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CanvasWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool goLeft, goRight, goUp, goDown;
        DispatcherTimer gameTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            canvas.Focus();

        }

        private Rectangle player;
        private void PlayerSpawn_Click(object sender, RoutedEventArgs e)
        {
            player = Hinzufügen(0, 0, 40, 40, Brushes.YellowGreen);
        }
        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                goLeft = true;
            }
            if (e.Key == Key.D)
            {
                goRight = true;
            }
            if (e.Key == Key.W)
            {
                goUp = true;
            }
            if (e.Key == Key.S)
            {
                goDown = true;
            }
        }
        private void keyIsUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.A)
            {
                goLeft = false;
            }
            if (e.Key == Key.D)
            {
                goRight = false;
            }
            if (e.Key == Key.W)
            {
                goUp = false;
            }
            if (e.Key == Key.S)
            {
                goDown = false;
            }
        }

        private void rechteck_Zeichnen_click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtXCoord.Text, out int xCord) && int.TryParse(txtYCoord.Text, out int yCord)
               && int.TryParse(txtWidth.Text, out int width) && int.TryParse(txtHigth.Text, out int hight))
            {
                Hinzufügen(xCord, yCord, width, hight, cbColor.Text);
            }
        }

        Random random = new Random();

        Rectangle Hinzufügen(int xCoord, int yCoord, int width, int hight, Brush farbe)
        {
            Rectangle rectangle = new Rectangle
            {


                Height = hight,
                Width = width,

            };

            rectangle.Fill = farbe;

            Canvas.SetLeft(rectangle, xCoord);
            Canvas.SetTop(rectangle, canvas.Height - hight - yCoord);

            canvas.Children.Add(rectangle);
            return rectangle;
        }

        Rectangle Hinzufügen(int xCoord, int yCoord, int width, int hight, string farbe)
        {

            {
                Brush brushToUse = null;

                switch (farbe)
                {
                    case "Rot":
                        brushToUse = Brushes.Red;
                        break;
                    default:
                        brushToUse = Brushes.Pink;
                        break;
                    case "Blau":
                        brushToUse = Brushes.Blue;
                        break;
                    case "Gelb":
                        brushToUse = Brushes.Yellow;
                        break;
                    case "Weiß":
                        brushToUse = Brushes.White;
                        break;
                    case "Schwarz":
                        brushToUse = Brushes.Black;
                        break;
                    case "Magenta":
                        brushToUse = Brushes.Magenta;
                        break;
                    case "Lila":
                        brushToUse = Brushes.Purple;
                        break;
                    case "Orange":
                        brushToUse = Brushes.Orange;
                        break;
                    case "Grün":
                        brushToUse = Brushes.Green;
                        break;
                    case "Zufällig":
                        brushToUse = new SolidColorBrush(Color.FromRgb((byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255)));
                        break;

                }



                return Hinzufügen(xCoord, yCoord, width, hight, brushToUse);
            }


        }
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();

        }

        private Rectangle zuAnimierendesRechteck;
        private DispatcherTimer timer;

        private void animate_Click(object sender, RoutedEventArgs e)
        {
            zuAnimierendesRechteck = canvas.Children.OfType<Rectangle>().LastOrDefault();

            if (zuAnimierendesRechteck != null)
            {
                counter = 0;

                if (timer != null)
                {
                    timer.Stop();
                }

                timer = new DispatcherTimer();

                timer.Interval = TimeSpan.FromMilliseconds(1);
                timer.Tick += Timer_Tick; ;
                timer.Start();
            }




        }

        int counter = 0;
        private double defaultGeschwindigkeit = 2;
        Direction currentDirection = Direction.rightToLeft;
        Dictionary<Rectangle, Direction> directions = new Dictionary<Rectangle, Direction>();
        Dictionary<Rectangle, Direction> directions2 = new Dictionary<Rectangle, Direction>();
        Dictionary<Rectangle, double> geschwindigkeit = new Dictionary<Rectangle, double>();
        List<Rectangle> intersectedRectangles = new List<Rectangle>();
        Dictionary<Rectangle, int> intersectedTicks = new Dictionary<Rectangle, int>();
        private double playerSpeed = 4;
        bool verwendeGlockenKurveGeschwindigkeit = false;
        public enum Direction
        {
            leftToRight,
            rightToLeft,
            topToBottom,
            bottomToTop


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            intersectedRectangles.Clear();
            foreach (Rectangle rect in canvas.Children.OfType<Rectangle>())
            {
                Direction direction = Direction.leftToRight;
                if (!directions.ContainsKey(rect))
                {
                    directions.Add(rect, Direction.leftToRight);
                }
                directions.TryGetValue(rect, out direction);

                Direction direction1 = Direction.topToBottom;
                if (!directions2.ContainsKey(rect))
                {
                    directions2.Add(rect, Direction.topToBottom);
                }

                directions2.TryGetValue(rect, out direction1);

                double newPosition = Canvas.GetLeft(rect);
                double newPosition1 = Canvas.GetTop(rect);

                if (!geschwindigkeit.ContainsKey(rect))
                {
                    geschwindigkeit.Add(rect, defaultGeschwindigkeit);
                }
                geschwindigkeit.TryGetValue(rect, out double aktuelleGeschwindigkeit);

                if (verwendeGlockenKurveGeschwindigkeit)
                {
                    int maxGeschw = 10;
                    int minGeschw = 1;

                    double weg = (newPosition / (canvas.ActualWidth / 2)) - 1;
                    double geschwindigkeitsFaktor = (weg - 1) * (weg - 1) * (weg + 1) * (weg + 1);

                    aktuelleGeschwindigkeit = Math.Abs((maxGeschw - minGeschw) * geschwindigkeitsFaktor + minGeschw);
                    if (aktuelleGeschwindigkeit < minGeschw)
                    {
                        aktuelleGeschwindigkeit = minGeschw;
                  }
            }  
            if (player == rect)
                     
            {
                if (goLeft == true && Canvas.GetLeft(player) > 5)
                {
                    Canvas.SetLeft(player, Canvas.GetLeft(player) - playerSpeed);
                }
                if (goRight == true && Canvas.GetLeft(player) + (player.Width + 20) < canvas.Width)
                {
                    Canvas.SetLeft(player, Canvas.GetLeft(player) + playerSpeed);
                }
                if (goUp == true && Canvas.GetTop(player) > 5)
                {
                    Canvas.SetTop(player, Canvas.GetTop(player) - playerSpeed);
                }
                if (goDown == true && Canvas.GetTop(player) + (player.Height * 2) < canvas.Height)
                {
                    Canvas.SetTop(player, Canvas.GetTop(player) + playerSpeed);
                }
                   

                    return;  
                }
            
                if (newPosition1 > canvas.DesiredSize.Height - rect.Height)
                {
                    direction1 = Direction.topToBottom;
                }
                else if (newPosition1 < 0)
                {
                    direction1 = Direction.bottomToTop;
                }
                if (direction1 == Direction.bottomToTop)
                {
                    newPosition1 += aktuelleGeschwindigkeit;
                }
                else
                {
                    newPosition1 -= aktuelleGeschwindigkeit;
                }


                if (newPosition > canvas.DesiredSize.Width - rect.Width)
                {
                    direction = Direction.rightToLeft;
                }
                else if (newPosition < 0)
                {
                    direction = Direction.leftToRight;
                }

                if (direction == Direction.leftToRight)
                {
                    newPosition += aktuelleGeschwindigkeit;
                }
                else
                {
                    newPosition -= aktuelleGeschwindigkeit;
                }



                directions[rect] = direction;
                directions2[rect] = direction1;

                Canvas.SetLeft(rect, newPosition);
                Canvas.SetTop(rect, newPosition1);

                {
                    double x = Canvas.GetLeft(rect);
                    double y = Canvas.GetTop(rect);
                    double width = rect.Width;
                    double height = rect.Height;


                    foreach (Rectangle innerRect in canvas.Children.OfType<Rectangle>())
                    {
                        if (rect != innerRect)
                        {
                            double innerX = Canvas.GetLeft(innerRect);
                            double innerY = Canvas.GetTop(innerRect);
                            double innerWidth = innerRect.Width;
                            double innerHeight = innerRect.Height;
                            double xMin = x;
                            double yMin = y;
                            double xMax = x + width;
                            double yMax = y + height;
                            Rect rect1 = new Rect(x, y, height, width);
                            Rect rect2 = new Rect(innerX, innerY, innerHeight, innerWidth);
                            bool intersects = rect1.IntersectsWith(rect2);

                            if (intersects)
                            {
                                intersectedRectangles.Add(innerRect);
                                rect.Fill = new SolidColorBrush(Color.FromRgb((byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255)));
                            }
                        }

                    }

                }
            }

            //ntersectedRectangles.Remove();
        }


        private void canvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point position = Mouse.GetPosition(canvas);

            List<Rectangle> rectanglesToRemove = new List<Rectangle>();

            foreach (Rectangle rect in canvas.Children.OfType<Rectangle>())
            {
                if (rect != player)
                {

                }
                int x = (int)Canvas.GetLeft(rect);
                int y = (int)Canvas.GetTop(rect);

                bool wurdeRechteckGeklickt = position.X >= x && position.X <= x + rect.Width
                        && position.Y >= y && position.Y <= y + rect.Height;

                if (clickModus.Text == "Farbe ändern" && wurdeRechteckGeklickt)
                {
                    rect.Fill = Brushes.Red;
                }
                else if (clickModus.Text == "Geschwindigkeit+" && wurdeRechteckGeklickt)
                {
                    geschwindigkeit[rect]++;
                    //geht aber bei zu oft fliegt raus
                }
                else if (clickModus.Text == "Geschwindigkeit-" && wurdeRechteckGeklickt)
                {
                    geschwindigkeit[rect]--;
                }



                else if (clickModus.Text == "Löschen" && wurdeRechteckGeklickt)
                {
                    rectanglesToRemove.Add(rect);
                }
            }

            if (clickModus.Text == "Hinzufügen")
            {
                /*if (int.TryParse(txtXCoord.Text, out int xCord) && 
                    && int.TryParse(txtHigth.Text, out int hight) && int.TryParse(txtWidth.Text, out int width))*/
                if (int.TryParse(txtHigth.Text, out int hight) && int.TryParse(txtWidth.Text, out int width))
                {
                    Hinzufügen((int)position.X, (int)(canvas.ActualHeight - position.Y), width, hight, cbColor.Text);
                }
                if (clickModus.Text == " Berührung")
                {

                }

            }


            foreach (Rectangle rect in rectanglesToRemove)
            {
                canvas.Children.Remove(rect);
            }

        }

        private void geschwZurücksetzt_Click(object sender, RoutedEventArgs e)
        {
            foreach (Rectangle rect in canvas.Children.OfType<Rectangle>())
            {
                geschwindigkeit[rect] = defaultGeschwindigkeit;
            }




        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            verwendeGlockenKurveGeschwindigkeit = !verwendeGlockenKurveGeschwindigkeit;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        private void RGB_Click(object sender, RoutedEventArgs e)
        {
            foreach (Rectangle rect in canvas.Children.OfType<Rectangle>())
            {
                rect.Fill = new SolidColorBrush(Color.FromRgb((byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255)));
            }
        }

        private void Farbänder_Click(object sender, RoutedEventArgs e)
        {
            

            

            foreach (Rectangle rect in canvas.Children.OfType<Rectangle>())
            {
                double x = Canvas.GetLeft(rect);
                double y = Canvas.GetTop(rect);
                double width = rect.Width;
                double height = rect.Height;


                foreach (Rectangle innerRect in canvas.Children.OfType<Rectangle>())
                {
                    if (rect != innerRect)
                    {
                        double innerX = Canvas.GetLeft(innerRect);
                        double innerY = Canvas.GetTop(innerRect);
                        double innerWidth = innerRect.Width;
                        double innerHeight = innerRect.Height;

                        double xMin = x;
                        double yMin = y;
                        double xMax = x + width;
                        double yMax = y + height;
                        Rect rect1 = new Rect(x, y, height, width);
                        Rect rect2 = new Rect(innerX, innerY, innerHeight, innerWidth);
                        bool intersects = rect1.IntersectsWith(rect2);

                        if (intersects)
                        {
                            rect.Fill = new SolidColorBrush(Color.FromRgb((byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255)));
                        }

                    }
              
                }
            }

        }
    }
}