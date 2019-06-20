using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Linq;
using System.Globalization;

namespace LoadingObjFormat
{
    public partial class Form1 : Form
    {
        private GLControl _glControl;

        private PointF _firstPoint = new PointF(-0.5f, -0.5f);
        private PointF _secondPoint = new PointF(0.5f, -0.5f);
        private PointF _thirdPoint = new PointF(-0.5f, 0.5f);

        private Color4 _objectColor = new Color4(0.1f, 0.7f, 0.2f, 1f);
        private Color4 _backgroundColor = new Color4(0.5f, 0.5f, 0.75f, 1f);

        // переменные для координат мыши и флаги - для отслеживания нажатия
        private float _mouseClickXPos = 0;
        private float _mouseClickYPos = 0;
        private bool _isLeftDown = false;
        private bool _isRightDown = false;

        private float _objectXPos = 0f;
        private float _objectYPos = 0f;
        private float _objectZPos = 0f;

        int coord_index = 0, Fase_index = 0;
        float coords;
        int Index;
        struct coord
        {
            float x;
            float y;
            float z;
        }

        struct poligons
        {
            coord point;
        }

        coord Mymass;
        poligons models;
        int point = 0;
        int p = 0;


        private enum ActivePlane    // Активная плоскость 0 - XY, 1 - XZ
        {
            XY, XZ
        }

        private ActivePlane _activePlane = ActivePlane.XY;

        public Form1()  // инициализация формы
        {
            InitializeComponent(); // инициализация компонентов

            _glControl = new GLControl();
            _glControl.Load += GLControl_Load;
            _glControl.Paint += GLControl_Paint;
            _glControl.MouseDown += GLControl_MousDown;
            _glControl.MouseUp += GLControl_MouseUP;
            _glControl.MouseMove += GLControl_MouseMove;
            _glControl.Dock = DockStyle.Fill;
            _tableLayoutPanel.Controls.Add(_glControl, 0, 0);
            _tableLayoutPanel.SetColumnSpan(_glControl, 2);
        }

        private Vector2 GetOpenGLMouseCoord(Vector2 coord)  // вектор координат 
        {
            Vector2 newCoord = new Vector2();
            newCoord.X = coord.X / _glControl.Width * 2f;
            newCoord.X -= 1f;
            newCoord.Y = (2 - 2 * coord.Y / _glControl.Height);
            newCoord.Y -= 1;
            return newCoord;
        }

        private void GLControl_MouseMove(object sender, MouseEventArgs e)   // перетаскивание объекта мышью
        {
            Vector2 mouseCoord = GetOpenGLMouseCoord(new Vector2(e.X, e.Y));
            float currentMouseXPos = mouseCoord.X;
            float currentMouseYPos = mouseCoord.Y;

            if (_isRightDown)
            {
                //Console.WriteLine(string.Format("({0}, {1})", e.X - _mouseClickXPos, _mouseClickYPos - e.Y));
                _objectXPos = currentMouseXPos;
                _objectYPos = currentMouseYPos;
            }
            _glControl.Invalidate();
        }

        private void GLControl_MousDown(object sender, MouseEventArgs e)    // контроль нажатия кнопок мыши
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                Vector2 mouseCoord = GetOpenGLMouseCoord(new Vector2(e.X, e.Y));
                _mouseClickXPos = mouseCoord.X;
                _mouseClickYPos = mouseCoord.Y;
                _objectXPos = _mouseClickXPos;
                _objectYPos = _mouseClickYPos;

                if (e.Button == MouseButtons.Left)  //  если левая кнопка
                {
                    _isLeftDown = true; // установить левый флаг
                }
                else       // иначе
                {
                    _isRightDown = true;    // установить правый
                }
            }
            _glControl.Invalidate();
        }

        private void GLControl_MouseUP(object sender, MouseEventArgs e)    // контроль отжатия кнопок мыши
        {
            if (e.Button == MouseButtons.Left)
            {
                _isLeftDown = false;    // снять флаг с левой кнопки
            }
            else if (e.Button == MouseButtons.Right)
            {
                _isRightDown = false;   // снять флаг с правой кнопки
            }
        }

        private void GLControl_Load(object sender, EventArgs e)     // активация функций перед рисованием 
        {
            // активация функций перед рисованием 
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.ColorMaterial);
        }

        private void DrawObject()       // ПРОРИСОВКА ТРЕУГОЛЬНИКА
        {
            GL.Begin(PrimitiveType.Triangles);
            {
                GL.Vertex2(_firstPoint.X, _firstPoint.Y);
                GL.Vertex2(_secondPoint.X, _secondPoint.Y);
                GL.Vertex2(_thirdPoint.X, _thirdPoint.Y);
            }
            GL.End();
        }

        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            GL.Viewport(0, 0, _glControl.Width, _glControl.Height); // определение размера окна для вывода прорисовки
            // Set background color
            GL.ClearColor(_backgroundColor);    // становка цвета фона
            // Set object color
            GL.Color4(_objectColor);    // установка цвета 
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            // прорисовка треугольника
            GL.PushMatrix();    // сохраняет текущую матрицу
            {
                GL.LoadIdentity();  // новая единичная матрица
                GL.Translate(_objectXPos, _objectYPos, _objectZPos); // сдвигает начало системы координат на ( Dx,Dy,Dz ).
                DrawObject();
            }
            GL.PushMatrix(); // вернуться к старым координатам
            _glControl.SwapBuffers();
        }

        //private void btnSetBGColor_Click(object sender, EventArgs e) // кнопка вызова диалога выбора цвета
        //{
        //    using (var colorDialog = new ColorDialog())
        //    {
        //        if (colorDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            _backgroundColor = colorDialog.Color;
        //        }
        //    }
        //    _glControl.Invalidate();
        //}

        //private void btnSetObjColor_Click(object sender, EventArgs e) // кнопка вызова диалога выбора цвета
        //{
        //    using (var colorDialog = new ColorDialog())
        //    {
        //        if (colorDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            _objectColor = colorDialog.Color;
        //        }
        //    }
        //    _glControl.Invalidate();
        //}

        private void setObjectColorToolStripMenuItem_Click(object sender, EventArgs e)  // смена цвета объекта
        {
            using (var colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _objectColor = colorDialog.Color;
                }
            }
            _glControl.Invalidate();
        }

        private void setBGColorToolStripMenuItem_Click(object sender, EventArgs e)  // смена цвета фона
        {
            using (var colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _backgroundColor = colorDialog.Color;
                }
            }
            _glControl.Invalidate();
        }

        private void loadOBJToolStripMenuItem_Click(object sender, EventArgs e) // кнопка менню загрузки файла obj
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "OBJ files (*.obj)|*.obj|All files (*.*)|*.*";

            string pathToExe = System.Reflection.Assembly.GetEntryAssembly().Location;
            OpenFile.InitialDirectory = Path.GetDirectoryName(pathToExe);

            OpenFile.Title = "Please select an OBJ file to encrypt.";
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("File is opened!");
                string FileName = OpenFile.FileName;    // сохраняем имя файла
                //string AllText = File.ReadAllText(FileName); // весь текст - вроде не надо
                //StreamReader StroksFile = new StreamReader(FileName);
                //StroksFile.Close();
                //GLControl_Paint(sender, 0);
                // переход на функцию рид_файл_обж
                Read_File_Obj(FileName);
            }
        }

        void Read_File_Obj(string name_file)
        {
            int counterV = 0, counterN = 0, counterT = 0, counter = 0;
            string line;
            if ((name_file) != null)
            {
                StreamReader StroksFile = new StreamReader(name_file);
                StroksFile.DiscardBufferedData();
                string[] str;
                int File_Size = 0;
                try
                {
                    string[] Stroka1 = StroksFile.ReadToEnd().Split('\n'); // разбитие файла построчно
                    Stroka1 = Stroka1.Where(n => !string.IsNullOrEmpty(n)).ToArray();
                    File_Size = Stroka1.Count();    // количество элементов в массиве, т.е. количество строк в файле

                    int countpoint = 0;
                    int countfase = 0;
                    float[] Mass_Ver = new float[File_Size * 3];  // над размером этих массивов надо еще подумать
                    float[] Mass_Norm = new float[File_Size * 3];
                    float[] Mass_Tex = new float[File_Size * 3];
                    int[] Mass_Poll = new int[File_Size * 3];  // над размером этих массивов надо еще подумать
                    // // разбивка файла
                    for (int i = 0; i < File_Size; i++)   // цикл по полличеству строк в файле
                    {
                        string[] RazS = Stroka1[i].Split(' ');  // разбиваем строку из массива строк на элементы, минуя пробелы как разделители

                        if (RazS.Count() > 2 && RazS.Count() < 5)   // если значений после разбития строки от 3 до 4, тогда это нужная нам строка
                        {
                            string tempD = RazS[0];
                            string Vershina = "v";
                            string Normal = "vn";
                            string Textura = "vt";
                            string Poligon = "f";
                           // float[,,] Mass_Ver; // трехмерный массив для координат вершины
                            float tempX = 0, tempY = 0, tempZ = 0;
                            for (int j = 0; j <1; j++) // организовать цикл прохода по полученным данным и разбивкой их на массивы - верщин, текстур и нормалей.
                           { // этот цикл по сути не нужен, можно переделать без него!!!!
                                
                                if (tempD == Vershina) // это вершина
                                {
                                        Mass_Ver[counterV + 0] = Convert.ToSingle(RazS[j + 1], new CultureInfo("en-US"));
                                        Mass_Ver[counterV + 1] = Convert.ToSingle(RazS[j + 2], new CultureInfo("en-US"));
                                        Mass_Ver[counterV + 2] = Convert.ToSingle(RazS[j + 3], new CultureInfo("en-US"));
                                        counterV += 3;
                                }
                                else if (tempD == Normal) // это нормаль
                                {
                                    Mass_Norm[counterN + 0] = Convert.ToSingle(RazS[j + 1], new CultureInfo("en-US"));
                                    Mass_Norm[counterN + 1] = Convert.ToSingle(RazS[j + 2], new CultureInfo("en-US"));
                                    Mass_Norm[counterN + 2] = Convert.ToSingle(RazS[j + 3], new CultureInfo("en-US"));
                                    counterN += 3;
                                }
                                else if (tempD == Textura) // это текстура
                                {
                                    Mass_Tex[counterT + 0] = Convert.ToSingle(RazS[j + 1], new CultureInfo("en-US"));
                                    Mass_Tex[counterT + 1] = Convert.ToSingle(RazS[j + 2], new CultureInfo("en-US"));
                                    if (RazS.Count() > 3)
                                    {
                                        Mass_Tex[counterT + 2] = Convert.ToSingle(RazS[j + 3], new CultureInfo("en-US"));
                                        counterT += 3;
                                    }
                                    else counterT += 2;
                                }
                                else if (tempD  == Poligon) // это полигон
                                {
                                    for (int k = 1; k < 4; k++)
                                    {
                                        string[] tempP1 = RazS[j + k].Split('/');
                                        Mass_Poll[counter + 0] = Convert.ToInt32(tempP1[0]);
                                        Mass_Poll[counter + 1] = Convert.ToInt32(tempP1[1]);
                                        Mass_Poll[counter + 2] = Convert.ToInt32(tempP1[2]);
                                        counter += 3;
                                    }                                    
                                }
                            }
                        }
                    }
                    StroksFile.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }       
        }
        

        //private void btnLoadFileOBJ_Click(object sender, EventArgs e)
        //{
        //    FileStream FileObj = new FileStream("D:/12345.obj", FileMode.Open, FileAccess.Read);
        //    StreamReader StrObj = new StreamReader(FileObj, System.Text.Encoding.Default);
        //    string[] MasStr;
        //    int i = 0;
        //    try
        //    {
        //        string[] MasStr1 = StrObj.ReadToEnd().Split('\n');
        //        MasStr1 = MasStr1.Where(n => !string.IsNullOrEmpty(n)).ToArray();
        //    }
        //    //MasStr = StrFileObj.ReadToEnd();
        //    //char[] chm = MasStr.ToCharArray(); 

    }
    }
