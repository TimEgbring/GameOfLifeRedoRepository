using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace GameOfLifeRedo
{
    public partial class Form1 : Form
    {
        
        
        readonly Brush dead_white = new SolidBrush(Color.FromArgb(255,255,255));
        readonly Brush mygrey1 = new SolidBrush(Color.FromArgb(192, 192, 192));
        readonly Brush mygrey2 = new SolidBrush(Color.FromArgb(128, 128, 128));
        readonly Brush mygrey3 = new SolidBrush(Color.FromArgb(64, 64, 64));
        readonly Brush full_black = new SolidBrush(Color.FromArgb(0, 0, 0));
        const int placeforinformation = 10;
        bool kopieren = false;
        bool mouseDown;
        Point mouseDownPoint = Point.Empty;
        int mouseDownRectangleNumber = 0;
        Point mousePoint = Point.Empty;
        bool[] isselectedbycopy;
        int last_selectedbycopy_top_left;
        int last_selectedbycopy_bottom_right;


        Graphics g = null;
        

        bool isrunning = false;
        bool gamehasstarted = false;
        bool[] isalive;
        bool[] hasaliveneighbors;
        byte[] aliveneighbors_count;
        byte[] bytegrid;
        byte[] bytegrid_new;
        bool[] bytegrid_haschanged;
        int[,] neighbors;
        byte[] neighbors_gradient_sum;
        Rectangle[] rect_grid;
        int generationcounter;
        DateTime time_start;
        enum Compass { N, E, S, W, NE, SE, SW, NW };

        static int top_left_x, top_left_y;
        static int bottom_right_x, bottom_right_y;
        

        static int cell_count_x, cell_count_y;
        public int sizeofcell = 15;
        public struct GameState
        {
            public int generationcounter;
            public int cell_count_x, cell_count_y;
            public bool isrunning;
            public int sizeofcell;
            public bool gameexists;
            public DateTime time_start;
            public Rectangle[] rect_grid;        
            public byte[] bytegrid;
            public byte[] bytegrid_new;
            public bool[] bytegrid_haschanged;
            public int top_left_x, top_left_y;
            public int bottom_right_x, bottom_right_y;
            public bool[] hasaliveneighbors;
            public byte[] aliveneighbors_count;
            public byte[] neighbors_gradient_sum;
            public bool[] isalive;
        }
        GameState gamestate;

        public Form1()
        {
            InitializeComponent();
            InitVorlagenToolstrip();
            int sz = Screen.PrimaryScreen.WorkingArea.Size.Width;
            int szh = Screen.PrimaryScreen.WorkingArea.Size.Height;
            
            this.Size = new Size(sz, szh);
            
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer| ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
            InitVariables();
            InitNeighbors();
            


            AdjustWinFrame();
            
            g = GridColorFlowPanel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            //ControlPaint.DrawFocusRectangle(g, new Rectangle(50, 50, 100, 100),Color.Green,Color.Black);

        }

        private GameState GetCurrentGameState()
        {
            GameState gstate = new GameState()
            {
                generationcounter = generationcounter,
                cell_count_x = cell_count_x,
                cell_count_y = cell_count_y,
                isrunning = isrunning,
                sizeofcell = sizeofcell,

                time_start = time_start,


                top_left_x = top_left_x,
                top_left_y = top_left_y,
                bottom_right_x = bottom_right_x,
                bottom_right_y = bottom_right_y,

                rect_grid = DeepCopy(rect_grid),
                bytegrid = DeepCopy(bytegrid),
                bytegrid_new = DeepCopy(bytegrid_new),
                bytegrid_haschanged = DeepCopy(bytegrid_haschanged),
                hasaliveneighbors = DeepCopy(hasaliveneighbors),
                aliveneighbors_count = DeepCopy(aliveneighbors_count),
                neighbors_gradient_sum = DeepCopy(neighbors_gradient_sum),
                isalive = DeepCopy(isalive),
            };

            return gstate;

        }
        public void SetCurrentGameState(GameState gstate)
        {
            generationcounter = gstate.generationcounter;
            cell_count_x = gstate.cell_count_x;
            cell_count_y = gstate.cell_count_y;
            isrunning = gstate.isrunning;
            sizeofcell = gstate.sizeofcell;
            time_start = gstate.time_start;
            top_left_x = gstate.top_left_x;
            top_left_y = gstate.top_left_y;
            bottom_right_x = gstate.bottom_right_x;
            bottom_right_y = gstate.bottom_right_y;
            rect_grid = DeepCopy(gstate.rect_grid);
            bytegrid = DeepCopy(gstate.bytegrid);
            bytegrid_new = DeepCopy(gstate.bytegrid_new);
            bytegrid_haschanged = DeepCopy(gstate.bytegrid_haschanged);
            hasaliveneighbors = DeepCopy(gstate.hasaliveneighbors);
            aliveneighbors_count = DeepCopy(gstate.aliveneighbors_count);
            neighbors_gradient_sum = DeepCopy(gstate.neighbors_gradient_sum);
            isalive = DeepCopy(gstate.isalive);
        }
        public static T DeepCopy<T>(T obj)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new Exception("The source object must be serializable");
            }
            if (Object.ReferenceEquals(obj, null))
            {
                throw new Exception("The source object must not be null");
            }
            T result = default(T);
            using (var memoryStream = new MemoryStream())
            {
                var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(memoryStream, obj);
                memoryStream.Seek(0, SeekOrigin.Begin);
                result = (T)formatter.Deserialize(memoryStream);
                memoryStream.Close();
            }
            return result;
            
        }
      
        private void ResetGame()
        {
            PauseGame();
            gamehasstarted = false;
            isalive = new bool[cell_count_x * cell_count_y];
            isselectedbycopy = new bool[cell_count_x * cell_count_y];
            hasaliveneighbors = new bool[cell_count_x * cell_count_y];
            aliveneighbors_count = new byte[cell_count_x * cell_count_y];
            bytegrid = new byte[cell_count_x * cell_count_y];
            bytegrid_new=new byte[cell_count_x * cell_count_y];
            bytegrid_haschanged=new bool[cell_count_x * cell_count_y];
            neighbors_gradient_sum = new byte[cell_count_x * cell_count_y];
            GridColorFlowPanel.Refresh();
            generationcounter = 0;
            Generation_Ctr_Label.Text = "0";
        }
        private void InitVariables()
        {
            top_left_x = GridColorFlowPanel.Location.X;
            top_left_y = GridColorFlowPanel.Location.Y;
            int tmp_bottom_right_x = top_left_x + GridColorFlowPanel.Width;
            int tmp_bottom_right_y = top_left_y + GridColorFlowPanel.Height - PanelBottom.Height;

            cell_count_x = (tmp_bottom_right_x - top_left_x - 1) / (sizeofcell + 1);

            cell_count_y = (tmp_bottom_right_y - top_left_y - 1) / (sizeofcell + 1);
            bottom_right_x = 1 + (sizeofcell + 1) * cell_count_x;
            bottom_right_y = 1 + (sizeofcell + 1) * cell_count_y;

            rect_grid = new Rectangle[cell_count_y * cell_count_x];
            for (int i = 0; i < cell_count_y; i++)
            {
                for (int j = 0; j < cell_count_x; j++)
                {
                    rect_grid[cell_count_x * i + j].X = top_left_x + j * sizeofcell + j + 1;
                    rect_grid[cell_count_x * i + j].Y = top_left_y + i * sizeofcell + i + 1;
                    rect_grid[cell_count_x * i + j].Size = new Size(sizeofcell, sizeofcell);
                }
            }
            bytegrid = new byte[cell_count_x * cell_count_y];

            isselectedbycopy = new bool[cell_count_x * cell_count_y];
            isalive = new bool[cell_count_x * cell_count_y];
            hasaliveneighbors = new bool[cell_count_x * cell_count_y];
            aliveneighbors_count = new byte[cell_count_x * cell_count_y];
            bytegrid_new = new byte[cell_count_x * cell_count_y];
            bytegrid_haschanged = new bool[cell_count_x * cell_count_y];
            neighbors = new int[cell_count_x * cell_count_y, 8];
            neighbors_gradient_sum = new byte[cell_count_x * cell_count_y];
        }
       
        private void ResetToNewSize()
        {
           ResetGame();

            //int sz = Screen.PrimaryScreen.WorkingArea.Size.Width;
            //int szh = Screen.PrimaryScreen.WorkingArea.Size.Height - 100;
            //this.Size = new Size(sz, szh);//WIESO GRIDCOLORPANEL.HEIGHT ÄNDERT
            

            InitVariables();
            

            InitNeighbors();
            ReAdjustWinFrame();
            g = null;
            g = GridColorFlowPanel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            
            GridColorFlowPanel.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //InitVariables();
            //AdjustWinFrame();


        }
        private void AdjustWinFrame()
        {
            //this.Size = new Size(1 + cell_count_x * (sizeofcell + 1) + 16, 1 + cell_count_y * (sizeofcell + 1) + PanelBottom.Height + 39);
            this.Size = new Size(bottom_right_x + 16, bottom_right_y + PanelBottom.Height + 39); //Offset from Form1 Size and InnerForm1 Size and MainMenu

        }
        private void ReAdjustWinFrame() //Seltsame Interaktion, in welcher GridColorPanel.Height sich ohne aufforderung nach initialisierung ändert. Vermutung: MainMenu
        {
            //this.Size = new Size(1 + cell_count_x * (sizeofcell + 1) + 16, 1 + cell_count_y * (sizeofcell + 1) + PanelBottom.Height + 39);
            this.Size = new Size(bottom_right_x + 16, bottom_right_y + PanelBottom.Height + 39+20); //Offset from Form1 Size and InnerForm1 Size and MainMenu

        }
        private void GenerationTimer_Tick(object sender, EventArgs e)
        {
            if (generationcounter == 500)
                Start_Button_Click(null, null);
            RuleSetModifiedShelter();
            Generation_Ctr_Label.Text = (++generationcounter).ToString();
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (!gamehasstarted)
            {
                gamehasstarted = true;
                gamestate = GetCurrentGameState();
            }
            for (int i = 0; i < cell_count_x*cell_count_y; i++)
            {
                bytegrid_new[i] = bytegrid[i];
            }
            if (!isrunning)
                StartGame();
            else
            {
                ElapsedTime.Show();
                ElapsedTime.Text = (DateTime.Now - time_start).ToString();
                PauseGame();
            }
        }

        private void StartGame()
        {
            Start_Button.Text = "Pause";
            isrunning = true;
            
            time_start = DateTime.Now;
            GenerationTimer.Start();
        }
        private void PauseGame()
        {
            Start_Button.Text = "Start";
            isrunning = false;
            GenerationTimer.Stop();
        }
       
        private void InitNeighbors()
        {
            for (int i = 0; i < cell_count_x * cell_count_y; i++)
            {

                if ((i + 1) % cell_count_x == 0)     // Handles EastBorder Overflow
                {
                    neighbors[i, (int)Compass.E] = i - cell_count_x + 1;
                }
                else                // Handles EastBorder
                {
                    neighbors[i, (int)Compass.E] = i + 1;
                }
                if (i < cell_count_x)         //Handles NorthBorder Overflow
                {
                    neighbors[i, (int)Compass.N] = i + cell_count_x*cell_count_y-cell_count_x;  // 870 = 30*30 - 30
                }
                else                // Handles NorthBorder
                {
                    neighbors[i, (int)Compass.N] = i - cell_count_x;
                }
                if (i % cell_count_x == 0)        //Handles WestBorder Overflow
                {
                    neighbors[i, (int)Compass.W] = i + cell_count_x - 1;
                }
                else              //Handles WestBorder
                {
                    neighbors[i, (int)Compass.W] = i - 1;
                }
                if (i >= cell_count_x * cell_count_y - cell_count_x)      //Handles SouthBorder Overflow
                {
                    neighbors[i, (int)Compass.S] = i - (cell_count_x*cell_count_y -cell_count_x);
                }
                else                //Handles SouthBorder
                {
                    neighbors[i, (int)Compass.S] = i + cell_count_x;
                }


                if ((i + 1) % cell_count_x == 0)        //Handles NorthEast
                {
                    if (i == cell_count_x-1)
                    {
                        neighbors[i, (int)Compass.NE] = cell_count_x * cell_count_y - cell_count_x;
                    }
                    else neighbors[i, (int)Compass.NE] = i - cell_count_x - cell_count_x+1;
                }
                else if (i < cell_count_x)
                {
                    neighbors[i, (int)Compass.NE] = i + cell_count_x * cell_count_y - cell_count_x + 1;
                }
                else neighbors[i, (int)Compass.NE] = i - cell_count_x + 1;

                if ((i + 1) % cell_count_x  == 0)        //Handles SouthEast
                {
                    if (i == cell_count_x*cell_count_y -1)
                    {
                        neighbors[i, (int)Compass.SE] = 0;
                    }
                    else neighbors[i, (int)Compass.SE] = i + 1;
                }
                else if (i >= cell_count_x * cell_count_y - cell_count_x)
                {
                    neighbors[i, (int)Compass.SE] = i - cell_count_x * cell_count_y + cell_count_x  + 1;
                }
                else neighbors[i, (int)Compass.SE] = i + cell_count_x + 1;

                if (i % cell_count_x == 0)        //Handles SouthWest
                {
                    if (i == cell_count_x * cell_count_y - cell_count_x)
                    {
                        neighbors[i, (int)Compass.SW] = cell_count_x - 1;
                    }
                    else neighbors[i, (int)Compass.SW] = i + cell_count_x + cell_count_x - 1;
                }
                else if (i >= cell_count_x * cell_count_y - cell_count_x)
                {
                    neighbors[i, (int)Compass.SW] = i - cell_count_x * cell_count_y + cell_count_x - 1;
                }
                else neighbors[i, (int)Compass.SW] = i + cell_count_x - 1;

                if (i < cell_count_x)        //Handles NorthWest
                {
                    if (i == 0)
                    {
                        neighbors[i, (int)Compass.NW] = cell_count_x * cell_count_y - 1;
                    }
                    else neighbors[i, (int)Compass.NW] = i + cell_count_x * cell_count_y - cell_count_x - 1;
                }
                else if (i % cell_count_x == 0)
                {
                    neighbors[i, (int)Compass.NW] = i - 1;
                }
                else neighbors[i, (int)Compass.NW] = i - cell_count_x - 1;
            }
        }
        private void AliveNeighborsIncBool(int buttonnumber)
        {

            for (int i = 0; i < 8; i++)
            {
                hasaliveneighbors[neighbors[buttonnumber, i]] = true;
                aliveneighbors_count[neighbors[buttonnumber, i]]++;
            }
        }
        private void AliveNeighborsDecBool(int buttonnumber)
        {

            for (int i = 0; i < 8; i++)
            {

                aliveneighbors_count[neighbors[buttonnumber, i]]--;

                hasaliveneighbors[neighbors[buttonnumber, i]] = (aliveneighbors_count[neighbors[buttonnumber, i]] != 0);
            }
        }
        private void NeighborGradientSumInc(int buttonnumber, int numberoftimes)
        {
            for (int j = 0; j < numberoftimes; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    hasaliveneighbors[neighbors[buttonnumber, i]] = true;
                    neighbors_gradient_sum[neighbors[buttonnumber, i]]++;

                }
            }

        }
        private void NeighborGradientSumInc(int buttonnumber)
        {
            
            for (int i = 0; i < 8; i++)
            {
                hasaliveneighbors[neighbors[buttonnumber, i]] = true;
                neighbors_gradient_sum[neighbors[buttonnumber, i]]++;

            }
           
        }
        
        private void NeighborGradientSumDec(int buttonnumber)
        {
            
            for (int i = 0; i < 8; i++)
            {
                neighbors_gradient_sum[neighbors[buttonnumber, i]]--;
                hasaliveneighbors[neighbors[buttonnumber, i]] = !(neighbors_gradient_sum[neighbors[buttonnumber, i]] == 0);
            }
        }
        private void UpdateColorAll()
        {
            
            int sumwhite = 0;
            int sumgrey1 = 0;
            int sumgrey2 = 0;
            int sumgrey3 = 0;
            int sumblack = 0;
            for(int i = 0; i < cell_count_x * cell_count_y; i++) //Parallel Foreach testen
            {
                if (bytegrid_haschanged[i])
                {

                    if (bytegrid[i] == 0)
                        sumwhite++;
                    else if (bytegrid[i] == 1)
                        sumgrey1++;
                    else if (bytegrid[i] == 2)
                        sumgrey2++;
                    else if (bytegrid[i] == 3)
                        sumgrey3++;
                    else
                        sumblack++;
                }
            }
            int whitecount = 0;
            int grey1count = 0;
            int grey2count = 0;
            int grey3count = 0;
            int blackcount = 0;
            Rectangle[] white = new Rectangle[sumwhite];
            Rectangle[] grey1 = new Rectangle[sumgrey1];
            Rectangle[] grey2 = new Rectangle[sumgrey2];
            Rectangle[] grey3 = new Rectangle[sumgrey3];
            Rectangle[] black = new Rectangle[sumblack];
            
            for (int i = 0; i < cell_count_x * cell_count_y; i++)
            {
                if (bytegrid_haschanged[i])
                {
                    if (bytegrid[i] == 0)
                        white[whitecount++] = rect_grid[i];
                    else if (bytegrid[i] == 1)
                        grey1[grey1count++] = rect_grid[i];
                    else if (bytegrid[i] == 2)
                        grey2[grey2count++] = rect_grid[i];
                    else if (bytegrid[i] == 3)
                        grey3[grey3count++] = rect_grid[i];
                    else
                        black[blackcount++] = rect_grid[i];
                }
            }


            if (white.Length != 0)
                g.FillRectangles(dead_white, white);
            if (grey1.Length != 0)
                g.FillRectangles(mygrey1, grey1);
            if (grey2.Length != 0)
                g.FillRectangles(mygrey2, grey2);
            if (grey3.Length != 0)
                g.FillRectangles(mygrey3, grey3);
            if (black.Length != 0)
                g.FillRectangles(full_black, black);
        }



        //private void RecalcVariables() //For later use to keep gridinformation like Rectangles etc
        //{
        //    top_left_x = GridColorFlowPanel.Location.X;
        //    top_left_y = GridColorFlowPanel.Location.Y;
        //    int tmp_bottom_right_x = top_left_x + GridColorFlowPanel.Width;
        //    int tmp_bottom_right_y = top_left_y + GridColorFlowPanel.Height - PanelBottom.Height;
        //    cell_count_x = (tmp_bottom_right_x - top_left_x - 1) / (sizeofcell + 1);

        //    cell_count_y = (tmp_bottom_right_y - top_left_y - 1) / (sizeofcell + 1);
        //    bottom_right_x = 1 + (sizeofcell + 1) * cell_count_x ;
        //    bottom_right_y = 1 + (sizeofcell + 1) * cell_count_y ;

        //    rect_grid = new Rectangle[cell_count_y * cell_count_x];
        //    for (int i = 0; i < cell_count_y; i++)
        //    {
        //        for (int j = 0; j < cell_count_x; j++)
        //        {
        //            rect_grid[cell_count_x * i + j].X = top_left_x + j * 15 + j + 1;
        //            rect_grid[cell_count_x * i + j].Y = top_left_y + i * 15 + i + 1;
        //            rect_grid[cell_count_x * i + j].Size = new Size(sizeofcell, sizeofcell);
        //        }
        //    }
        //}

        private void GridColorFlowPanel_Paint(object sender, PaintEventArgs e)
        {
            
            
            InitLineGrid();
            // e.Graphics.TranslateTransform(GridColorFlowPanel.AutoScrollPosition.X, GridColorFlowPanel.AutoScrollPosition.Y);
        }

        private void InitLineGrid()
        {
            for(int i = 0; i < cell_count_x; i++)
            {
                g.DrawLine(new Pen(Color.LightGray), rect_grid[i].X-1, top_left_y, rect_grid[i].X-1, bottom_right_y-1);

            }
            g.DrawLine(new Pen(Color.LightGray), rect_grid[cell_count_x-1].X +sizeofcell, top_left_y, rect_grid[cell_count_x-1].X +sizeofcell, bottom_right_y-1);
            for (int i = 0; i < cell_count_y; i++)
            {
                g.DrawLine(new Pen(Color.LightGray), top_left_x, rect_grid[i*cell_count_x].Y-1, bottom_right_x-1, rect_grid[i * cell_count_x].Y-1);
            }
            g.DrawLine(new Pen(Color.LightGray), top_left_x, rect_grid[cell_count_y * cell_count_x-1].Y +sizeofcell, bottom_right_x - 1, rect_grid[cell_count_y * cell_count_x-1].Y +sizeofcell);
        }

        

        private void FullSymmetric_Button_Click(object sender, EventArgs e)
        {
            ResetGame();
            GenerateFullSymmetric();
        }

        private void RuleSetModifiedShelter()
        {

            for (int i = 0; i < cell_count_x*cell_count_y; i++)
            {
                if (hasaliveneighbors[i] || isalive[i])
                {       //Calculates Bytegrid_new

                    if (neighbors_gradient_sum[i] == 12 || neighbors_gradient_sum[i] == 16 || neighbors_gradient_sum[i] == 20)
                    {
                        bytegrid_new[i] = bytegrid[i];
                    }
                    else if (neighbors_gradient_sum[i] < DecBelow.Value || neighbors_gradient_sum[i] > DecAbove.Value) //Too small or too big
                    {
                        if (isalive[i])
                        {
                            bytegrid_new[i]--;
                        }
                    }
                    else if (neighbors_gradient_sum[i] > IncAbove.Value && neighbors_gradient_sum[i] < IncBelow.Value) //Just right
                    {
                        if (bytegrid[i] != 4)
                        {

                            bytegrid_new[i]++;

                        }
                        
                    }
                    else //enough to survive
                    {
                        bytegrid_new[i] = bytegrid[i];
                    }
                }
            }
            BytegridChangeAction();
            for (int i = 0; i < cell_count_x*cell_count_y; i++)
            {
                bytegrid[i] = bytegrid_new[i];
            }
            UpdateColorAll();
        }

        private void GridPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mousePoint = mouseDownPoint = e.Location;

            if (e.Button == MouseButtons.Left) {
                
                for (int i = 0; i < cell_count_x * cell_count_y; i++)
                {
                    if (mousePoint.X >= rect_grid[i].Location.X && mousePoint.Y >= rect_grid[i].Location.Y)
                    {
                        if (mousePoint.X <= rect_grid[i].Location.X + sizeofcell && mousePoint.Y <= rect_grid[i].Location.Y + sizeofcell)
                        {
                            mouseDownRectangleNumber = i;
                            if (!kopieren)
                            {
                                RectClick(i);
                            }
                            else mouseDownPoint = rect_grid[mouseDownRectangleNumber].Location;

                        }
                                
                    }
                }
                
            }
        }
        
        private Rectangle NewRectangleByPoints(Point p1, Point p2) //nehme an dass width und height neg sein können
        {

            return new Rectangle(p1,new Size(p2.X - p1.X, p2.Y - p1.Y));
        }
        

        
        private void ModifiedButtonIncGeneralized(int gnumber, int numberoftimes)
        {
            for (int i = 0; i < numberoftimes; i++)
            {
                if (!isalive[gnumber])
                {
                    isalive[gnumber] = true;
                    AliveNeighborsIncBool(gnumber);
                }
                NeighborGradientSumInc(gnumber);
            }


        }
        private void ModifiedButtonIncGeneralized(int gnumber)
        {
            if (!isalive[gnumber])
            {
                isalive[gnumber] = true;
                AliveNeighborsIncBool(gnumber);
            }
            NeighborGradientSumInc(gnumber);


        }
        
        private void RectClick(int gnumber)
        {
            if (bytegrid[gnumber]== 0) 
            {
                g.FillRectangle(mygrey1, rect_grid[gnumber]);
                bytegrid[gnumber] = 1;
                bytegrid_new[gnumber] = 1;
                ModifiedButtonIncGeneralized(gnumber);
            }
            else if (bytegrid[gnumber] == 1)
            {
                g.FillRectangle(mygrey2, rect_grid[gnumber]);
                bytegrid[gnumber] = 2;
                bytegrid_new[gnumber] = 2;
                ModifiedButtonIncGeneralized(gnumber);

            }
            else if (bytegrid[gnumber] == 2)
            {
                g.FillRectangle(mygrey3, rect_grid[gnumber]);
                bytegrid[gnumber] = 3;
                bytegrid_new[gnumber] = 3;
               
                ModifiedButtonIncGeneralized(gnumber);

            }
            else if (bytegrid[gnumber] == 3)
            {
                g.FillRectangle(full_black, rect_grid[gnumber]);
                bytegrid[gnumber] = 4;
                bytegrid_new[gnumber] = 4;
               
                ModifiedButtonIncGeneralized(gnumber);

            }
            else if (bytegrid[gnumber] == 4)
            {
                g.FillRectangle(dead_white, rect_grid[gnumber]);
                bytegrid[gnumber] = 0;
                bytegrid_new[gnumber] = 0;
                
                AliveNeighborsDecBool(gnumber);
                isalive[gnumber] = false;
                for (int i = 0; i < 4; i++)
                    NeighborGradientSumDec(gnumber);
            }
        }
        private byte[] SplitUIntToBytes(uint integer)
        {
            
            List<byte> prebytes = new List<byte>();
            
            if (integer >= Math.Pow(2, 24))
            {
                prebytes.Add((byte)(integer >> 24));
                
            }
            if (integer >= Math.Pow(2, 16))
            {
                if (integer < Math.Pow(2, 24))
                    prebytes.Add(0);
                prebytes.Add((byte)((integer << 8) >> 24));
            }
            if (integer >= Math.Pow(2, 8))
            {
                prebytes.Add((byte)((integer << 16) >> 24));
            }

            prebytes.Add((byte)((integer << 24) >> 24));
            
                byte[] finalbytes = prebytes.ToArray();

            return finalbytes;
        }
        private int ConvertBytesToInt(byte[] bytes)
        {
            
            int res = 0;
            for(int i = 0; i <  bytes.Length; i++)
            {
                res += (int)(bytes[i] * Math.Pow(256, bytes.Length - i-1));
            }
            return res;
        }
        
        private void Submit_Template_Button_Click(object sender, EventArgs e)
        {
            PauseGame();
            if (Submit_TextBox.Text == "")
            {
                MessageBox.Show("Fehler: Feld darf nicht leer bleiben!");
                return;
            }
            Submit_TextBox.ReadOnly = true;
            string tmp_fileName = Submit_TextBox.Text + ".txt";
            string fullPath = Path.GetFullPath(tmp_fileName);
            string directoryName = Path.GetDirectoryName(fullPath);
            
            string vorlagenDirectoryName = directoryName + "\\Vorlagen";

            if (!Directory.Exists(vorlagenDirectoryName))
            {
                Directory.CreateDirectory(vorlagenDirectoryName);
            }
            string fileName = vorlagenDirectoryName + "\\" + tmp_fileName;
            if (File.Exists(fileName))
                MessageBox.Show("Fehler: Eine Vorlage mit diesem Namen besteht bereits");
            else
            {
                
                byte[] brid_and_info = new byte[placeforinformation+cell_count_x * cell_count_y];
                for (int i = 0; i < cell_count_x * cell_count_y; i++)
                {
                    brid_and_info[i+placeforinformation] = bytegrid[i];


                }
                byte[] bcellcountx = SplitUIntToBytes((uint)cell_count_x);
                brid_and_info[0] = (byte) bcellcountx.Length;
                for (int i = 0; i < bcellcountx.Length; i++)
                {
                    brid_and_info[1 + i] = bcellcountx[i];
                }
                byte[] bcellcounty = SplitUIntToBytes((uint)cell_count_y);
                brid_and_info[bcellcountx.Length+1] = (byte)bcellcounty.Length;
                for (int i = 0; i < bcellcounty.Length; i++)
                {
                    brid_and_info[bcellcountx.Length +1 +1 + i] = bcellcounty[i];
                }


                File.WriteAllBytes(fileName, brid_and_info);
                //Start
                MenuItem testMenuItem;
                testMenuItem = new MenuItem();
                    Vorlagen_menuItem.MenuItems.AddRange(new MenuItem[] {
                testMenuItem
                });
                testMenuItem.Name = Path.GetFileNameWithoutExtension(fileName);
                
                testMenuItem.Text = Path.GetFileNameWithoutExtension(fileName);
                testMenuItem.Click += new System.EventHandler(LoadVorlage_Click);



                MessageBox.Show("Vorlage " + Path.GetFileNameWithoutExtension(fileName) + " wurde erfolgreich gespeichert.");
            }
            Submit_TextBox.ReadOnly = false;
            Submit_TextBox.Hide();
            Submit_Template_Button.Hide();
            Vorlagenname_label.Hide();

        }

        private void LoadVorlage_Click(object sender, EventArgs e)
        {
            byte[] loadable_grid;
            string cd = Directory.GetCurrentDirectory(); // \Debug
            string vcd;
            if (Directory.Exists(cd + "\\Vorlagen")) // Existiert
            {
                ResetGame();
                vcd = cd + @"\Vorlagen\";
                
                loadable_grid = File.ReadAllBytes(vcd + ((MenuItem)sender).Name + ".txt");

                int lenccountx = loadable_grid[0];
                int lenccounty = loadable_grid[lenccountx+1];
                byte[] ccountx = new byte[lenccountx];
                byte[] ccounty = new byte[lenccounty];
                for (int i = 0; i < lenccountx; i++)
                {
                    ccountx[i] = loadable_grid[1 + i];
                }
                for (int i = 0; i < lenccounty; i++)
                {
                    ccounty[i] = loadable_grid[lenccountx+ 1+1 + i];
                }

                cell_count_x = ConvertBytesToInt(ccountx);
                cell_count_y = ConvertBytesToInt(ccounty);


                
                AdjustLoadedWinFrame();
                AdjustVariablesLoad();
                InitNeighbors();
                for (int i = 0; i < cell_count_x*cell_count_y; i++)
                {
                    for (int j = 0; j < loadable_grid[i+placeforinformation]; j++)
                    {
                    RectClick(i);
                    }
                }
                
            }

            else MessageBox.Show("Es wurde kein Ordner mit dem Namen \"Vorlagen\" gefunden.");


        }
        private void AdjustVariablesLoad()
        {
            top_left_x = GridColorFlowPanel.Location.X;
            top_left_y = GridColorFlowPanel.Location.Y;
            rect_grid = new Rectangle[cell_count_y * cell_count_x];
            for (int i = 0; i < cell_count_y; i++)
            {
                for (int j = 0; j < cell_count_x; j++)
                {
                    rect_grid[cell_count_x * i + j].X = top_left_x + j * sizeofcell + j + 1;
                    rect_grid[cell_count_x * i + j].Y = top_left_y + i * sizeofcell + i + 1;
                    rect_grid[cell_count_x * i + j].Size = new Size(sizeofcell, sizeofcell);
                }
            }
            bytegrid = new byte[cell_count_x * cell_count_y];

            isselectedbycopy = new bool[cell_count_x * cell_count_y];
            isalive = new bool[cell_count_x * cell_count_y];
            hasaliveneighbors = new bool[cell_count_x * cell_count_y];
            aliveneighbors_count = new byte[cell_count_x * cell_count_y];
            bytegrid_new = new byte[cell_count_x * cell_count_y];
            bytegrid_haschanged = new bool[cell_count_x * cell_count_y];
            neighbors = new int[cell_count_x * cell_count_y, 8];
            neighbors_gradient_sum = new byte[cell_count_x * cell_count_y];
        }
        private void AdjustLoadedWinFrame()
        {
            
            bottom_right_x = 1 + cell_count_x * (sizeofcell+1);
            bottom_right_y = 1 + cell_count_y * (sizeofcell+1);
            this.Size = new Size(bottom_right_x + 16, bottom_right_y + PanelBottom.Height + 39+20);
            
        }
        private void InitVorlagenToolstrip()
        {
            string path = Directory.GetCurrentDirectory() + "\\Vorlagen";
            
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            

            
            foreach (string file in Directory.GetFiles((Directory.GetCurrentDirectory() + "\\Vorlagen\\") /*,".txt"*/))
            {
                string filename = Path.GetFileNameWithoutExtension(file);

               MenuItem testMenuItem;
                testMenuItem = new MenuItem();
                Vorlagen_menuItem.MenuItems.AddRange(new MenuItem[] {
                testMenuItem
                });

                testMenuItem.Name = filename;
                
                testMenuItem.Text = filename;
                testMenuItem.Click += new System.EventHandler(LoadVorlage_Click);

            }

        }
        private Brush ByteToBrush(byte gnumber)
        {

            if (gnumber == 0)
                return new SolidBrush(Color.FromArgb(255,255,255));
            if (gnumber == 1)
                return new SolidBrush(Color.FromArgb(192, 192, 192));
            if (gnumber == 2)
                return new SolidBrush(Color.FromArgb(128, 128, 128));
            if (gnumber == 3)
                return new SolidBrush(Color.FromArgb(64, 64, 64));
            else
                return new SolidBrush(Color.FromArgb(0, 0, 0));
            
        }
        private void ManualTick_Button_Click(object sender, EventArgs e)
        {
            
            RuleSetModifiedShelter();
        }

        private void Rand_Button_Click(object sender, EventArgs e)
        {
            ResetGame();
            Randomize();
        }

        private void neues_Spiel_MenuItem_Click(object sender, EventArgs e)
        {
            
            //ResetGame();
            ResetToNewSize();
            //GridColorFlowPanel.Refresh();
        }

        private void TBarIncBelow_ValueChanged(object sender, EventArgs e)
        {

        }

        private void RegelnAnpassenMenu_Click(object sender, EventArgs e)
        {
            GroupBoxVersionChange.Show();
        }

        private void Button_fertig_regeln_anpassen_Click(object sender, EventArgs e)
        {
            GroupBoxVersionChange.Hide();
        }

        private void DecBelow_ValueChanged(object sender, EventArgs e)
        {
            if(DecBelow.Value > IncAbove.Value)
            {
                IncAbove.Value=DecBelow.Value -1;
            }
        }

        private void IncAbove_ValueChanged(object sender, EventArgs e)
        {
            if(IncAbove.Value < DecBelow.Value)
            {
                DecBelow.Value = IncAbove.Value + 1;
            }
        }

        private void IncBelow_ValueChanged(object sender, EventArgs e)
        {
            if (IncBelow.Value > DecAbove.Value)
            {
                DecAbove.Value = IncBelow.Value + 1;
            }
        }

        private void DecAbove_ValueChanged(object sender, EventArgs e)
        {
            if (DecAbove.Value < IncBelow.Value)
            {
                IncBelow.Value = DecAbove.Value - 1;
            }
        }

        private void GridColorSizeChanged(object sender, EventArgs e)
        {
            if(g != null && GridColorFlowPanel.Region!=null)
                g.Clip = GridColorFlowPanel.Region;
        }

        private void VorlageSpeichern_MenuItem_Click(object sender, EventArgs e)
        {
            Submit_Template_Button.Show();
            Submit_TextBox.Show();
            Vorlagenname_label.Show();
        }

        

        private void AnfangsZustand_MenuItem_Click(object sender, EventArgs e)
        {
            if (gamestate.bytegrid == null)
            {
                MessageBox.Show("Es wurde noch kein Spiel gestartet");
                return;
            }
            ResetGame();
            SetCurrentGameState(gamestate);
                for (int i = 0; i < cell_count_x*cell_count_y; i++)
                {
                g.FillRectangle(ByteToBrush(bytegrid[i]), rect_grid[i]);
                }
                
            

            
        }

        private void Checkpunkt_MenuItem_Click(object sender, EventArgs e)
        {
            gamestate = GetCurrentGameState();
            
        }

        private void Kopieren_menuItem_Click(object sender, EventArgs e)
        {
            kopieren = true;
            Start_Button.Enabled = false;
            Information_groupBox.Show();
            Information_TextBox.Text = "Abbrechen: ESC";
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            //this.SuspendLayout();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            //this.ResumeLayout();
        }

       


        private void kopieren_button_Click(object sender, EventArgs e)
        {

        }

        private void Einfügen_menuItem_Click(object sender, EventArgs e)
        {

        }

        private void GridColorFlowPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

        }

        private void GridColorFlowPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && kopieren && e.Location.X > GridColorFlowPanel.ClientRectangle.Left && e.Location.X < GridColorFlowPanel.ClientRectangle.Right && e.Location.Y > GridColorFlowPanel.ClientRectangle.Top && e.Location.Y < GridColorFlowPanel.ClientRectangle.Bottom - PanelBottom.Height)
            {
                mousePoint = e.Location;

                
                int diffnumberx = (mousePoint.X - mouseDownPoint.X) / (sizeofcell + 1);
                int diffnumbery = (mousePoint.Y - mouseDownPoint.Y) / (sizeofcell + 1);
                
                if (diffnumberx < 0 || ((mousePoint.X - mouseDownPoint.X < 0 && mousePoint.X - mouseDownPoint.X > -(sizeofcell + 1))))
                    diffnumberx--;
                if (diffnumbery < 0 || (mousePoint.Y - mouseDownPoint.Y < 0 && mousePoint.Y - mouseDownPoint.Y > -(sizeofcell + 1)))
                    diffnumbery--;
                
                if (mouseDownRectangleNumber + diffnumberx + diffnumbery * cell_count_x < 0)
                {
                    diffnumbery++;
                }
                int bo_ri = mouseDownRectangleNumber + diffnumberx + diffnumbery*cell_count_x;
                int to_ri = mouseDownRectangleNumber + diffnumberx;
                int bo_le = mouseDownRectangleNumber + diffnumbery * cell_count_x;
                
                int true_to_le = (new int[] { mouseDownRectangleNumber, to_ri, bo_le, bo_ri }).Min();
                

                int true_bo_ri = (new int[] { mouseDownRectangleNumber, to_ri, bo_le, bo_ri }).Max();

                for (int i = 0; i < cell_count_x*cell_count_y; i++)
                {
                    if (isselectedbycopy[i])
                    {
                        if (!((i % cell_count_x >= true_to_le % cell_count_x && i % cell_count_x <= true_bo_ri % cell_count_x) && i >= last_selectedbycopy_top_left && i <= last_selectedbycopy_bottom_right))
                        {
                            isselectedbycopy[i] = false; ;
                            g.FillRectangle(ByteToBrush(bytegrid[i]), rect_grid[i]);
                        }
                    }
                }

                for (int i = 0; i <= Math.Abs(diffnumbery); i++)
                {
                    for (int j = 0; j <= Math.Abs(diffnumberx); j++)
                    {
                        int gnumber = true_to_le + j + i * cell_count_x;
                        if (!isselectedbycopy[gnumber])
                        {
                            isselectedbycopy[gnumber] = true;
                            g.FillRectangle(SelectBrushChange((byte)(bytegrid[gnumber])), rect_grid[gnumber]);
                        }
                        
                    }
                }
                


                last_selectedbycopy_top_left = true_to_le;
                last_selectedbycopy_bottom_right = true_bo_ri;
                
            }

        }
        private Brush SelectBrushChange(int gnumber)
        {
            if (gnumber == 0)
                return new SolidBrush(Color.FromArgb(192, 192, 255));
            if (gnumber == 1)
                return new SolidBrush(Color.FromArgb(144, 144, 255));
            if (gnumber == 2)
                return new SolidBrush(Color.FromArgb(96, 96, 192));
            if (gnumber == 3)
                return new SolidBrush(Color.FromArgb(48, 48, 128));
            else
                return new SolidBrush(Color.FromArgb(0, 0, 64));
        }
        private void menuItem6_Click(object sender, EventArgs e)
        {

        }

        private void BytegridChangeAction()
        {
            for (int i = 0; i < cell_count_x * cell_count_y; i++)
            {
                if (bytegrid_new[i] < bytegrid[i])
                {
                    bytegrid_haschanged[i] = true;
                    NeighborGradientSumDec(i);
                    
                    if (bytegrid_new[i] == 0)
                    {
                        AliveNeighborsDecBool(i);
                        isalive[i] = false;
                    }
                    
                        


                }
                else if (bytegrid_new[i] > bytegrid[i])
                {
                    bytegrid_haschanged[i] = true;
                    ModifiedButtonIncGeneralized(i);

                    

                }
                else
                {

                    bytegrid_haschanged[i] = false;
                }
            }
        }
        
        private void GenerateFullSymmetric() //Implement parity difference (middle line or 2 middle lines?)
        {
            byte range = 40;
            Random rnd = new Random();
            if (range*2 > cell_count_x || range*2 > cell_count_y)
            {
                MessageBox.Show("Range ist zu groß");
                return;
            }
            if (cell_count_x % 2 != cell_count_y % 2)
            {
               MessageBox.Show("True Symmetric ist verschoben");

            }
            for (int i = 0; i < range; i++)
            {
                for (int j = 0; j < range - i; j++)
                {

                    
                    
                        int point1 = (cell_count_y / 2 * cell_count_x - cell_count_x/2);
                        int point2 = point1 + 1;
                        int point3 = point1 + cell_count_x;
                        int point4 = point3 + 1;


                        int n1 = point1 - (cell_count_x + 1) * range + cell_count_x * i + j + i + cell_count_x;
                        int n12 = n1 + (cell_count_x - 1) * j;
                        int n2 = point2 - (cell_count_x - 1) * range + cell_count_x * i - j - i - 2 + cell_count_x;
                        int n22 = n2 + (cell_count_x + 1) * j;
                        int n3 = point3 + (cell_count_x - 1) * range - cell_count_x * i + j + i - cell_count_x;
                        int n32 = n3 - (cell_count_x + 1) * j;
                        int n4 = point4 + (cell_count_x + 1) * range - cell_count_x * i - j - i - 2 - cell_count_x;
                        int n42 = n4 - (cell_count_x - 1) * j;
                        switch (rnd.Next(0, 5))
                        {
                            case 0:
                                g.FillRectangle(dead_white, rect_grid[n1]);
                                bytegrid[n1] = 0;
                                isalive[n1] = false;

                                g.FillRectangle(dead_white, rect_grid[n2]);
                                bytegrid[n2] = 0;
                                isalive[n2] = false;

                                g.FillRectangle(dead_white, rect_grid[n3]);
                                bytegrid[n3] = 0;
                                isalive[n3] = false;

                                g.FillRectangle(dead_white, rect_grid[n4]);
                                bytegrid[n4] = 0;
                                isalive[n4] = false;

                                g.FillRectangle(dead_white, rect_grid[n12]);
                                bytegrid[n12] = 0;
                                isalive[n12] = false;

                                g.FillRectangle(dead_white, rect_grid[n22]);
                                bytegrid[n22] = 0;
                                isalive[n22] = false;

                                g.FillRectangle(dead_white, rect_grid[n32]);
                                bytegrid[n32] = 0;
                                isalive[n32] = false;

                                g.FillRectangle(dead_white, rect_grid[n42]);
                                bytegrid[n42] = 0;
                                isalive[n42] = false;

                                break;
                            case 1:
                                g.FillRectangle(mygrey1, rect_grid[n1]);
                                bytegrid[n1] = 1;
                                AliveNeighborsIncBool(n1);
                                isalive[n1] = true;
                                NeighborGradientSumInc(n1);

                                g.FillRectangle(mygrey1, rect_grid[n2]);
                                bytegrid[n2] = 1;
                                AliveNeighborsIncBool(n2);
                                isalive[n2] = true;
                                NeighborGradientSumInc(n2);

                                g.FillRectangle(mygrey1, rect_grid[n3]);
                                bytegrid[n3] = 1;
                                AliveNeighborsIncBool(n3);
                                isalive[n3] = true;
                                NeighborGradientSumInc(n3);

                                g.FillRectangle(mygrey1, rect_grid[n4]);
                                bytegrid[n4] = 1;
                                AliveNeighborsIncBool(n4);
                                isalive[n4] = true;
                                NeighborGradientSumInc(n4);
                                if (n1 != n12)
                                {
                                    g.FillRectangle(mygrey1, rect_grid[n12]);
                                    bytegrid[n12] = 1;
                                    AliveNeighborsIncBool(n12);
                                    isalive[n12] = true;
                                    NeighborGradientSumInc(n12);

                                    g.FillRectangle(mygrey1, rect_grid[n22]);
                                    bytegrid[n22] = 1;
                                    AliveNeighborsIncBool(n22);
                                    isalive[n22] = true;
                                    NeighborGradientSumInc(n22);

                                    g.FillRectangle(mygrey1, rect_grid[n32]);
                                    bytegrid[n32] = 1;
                                    AliveNeighborsIncBool(n32);
                                    isalive[n32] = true;
                                    NeighborGradientSumInc(n32);

                                    g.FillRectangle(mygrey1, rect_grid[n42]);
                                    bytegrid[n42] = 1;
                                    AliveNeighborsIncBool(n42);
                                    isalive[n42] = true;
                                    NeighborGradientSumInc(n42);

                                }
                                break;
                            case 2:
                                g.FillRectangle(mygrey2, rect_grid[n1]);
                                bytegrid[n1] = 2;
                                AliveNeighborsIncBool(n1);
                                isalive[n1] = true;
                                    NeighborGradientSumInc(n1, 2);
                                g.FillRectangle(mygrey2, rect_grid[n2]);
                                bytegrid[n2] = 2;
                                AliveNeighborsIncBool(n2);
                                isalive[n2] = true;
                                    NeighborGradientSumInc(n2,2);
                                g.FillRectangle(mygrey2, rect_grid[n3]);
                                bytegrid[n3] = 2;
                                AliveNeighborsIncBool(n3);
                                isalive[n3] = true;
                                    NeighborGradientSumInc(n3,2);
                                g.FillRectangle(mygrey2, rect_grid[n4]);
                                bytegrid[n4] = 2;
                                AliveNeighborsIncBool(n4);
                                isalive[n4] = true;
                                    NeighborGradientSumInc(n4,2);
                                if (n1 != n12)
                                {
                                    g.FillRectangle(mygrey2, rect_grid[n12]);
                                    bytegrid[n12] = 2;
                                    AliveNeighborsIncBool(n12);
                                    isalive[n12] = true;
                                        NeighborGradientSumInc(n12,2);
                                    g.FillRectangle(mygrey2, rect_grid[n22]);
                                    bytegrid[n22] = 2;
                                    AliveNeighborsIncBool(n22);
                                    isalive[n22] = true;
                                        NeighborGradientSumInc(n22,2);
                                    g.FillRectangle(mygrey2, rect_grid[n32]);
                                    bytegrid[n32] = 2;
                                    AliveNeighborsIncBool(n32);
                                    isalive[n32] = true;
                                        NeighborGradientSumInc(n32 ,2);
                                    g.FillRectangle(mygrey2, rect_grid[n42]);
                                    bytegrid[n42] = 2;
                                    AliveNeighborsIncBool(n42);
                                    isalive[n42] = true;
                                    
                                        NeighborGradientSumInc(n42, 2);
                                    
                                }
                                break;
                            case 3:
                                g.FillRectangle(mygrey3, rect_grid[n1]);
                                bytegrid[n1] = 3;
                                AliveNeighborsIncBool(n1);
                                isalive[n1] = true;

                                
                                    NeighborGradientSumInc(n1, 3);
                                

                                g.FillRectangle(mygrey3, rect_grid[n2]);
                                bytegrid[n2] = 3;
                                AliveNeighborsIncBool(n2);
                                isalive[n2] = true;

                                
                                    NeighborGradientSumInc(n2, 3);
                                

                                g.FillRectangle(mygrey3, rect_grid[n3]);
                                bytegrid[n3] = 3;
                                AliveNeighborsIncBool(n3);
                                isalive[n3] = true;

                                
                                    NeighborGradientSumInc(n3, 3);
                                

                                g.FillRectangle(mygrey3, rect_grid[n4]);
                                bytegrid[n4] = 3;
                                AliveNeighborsIncBool(n4);
                                isalive[n4] = true;

                                
                                    NeighborGradientSumInc(n4, 3);
                                
                                if (n1 != n12)
                                {
                                    g.FillRectangle(mygrey3, rect_grid[n12]);
                                    bytegrid[n12] = 3;
                                    AliveNeighborsIncBool(n12);
                                    isalive[n12] = true;

                                    
                                        NeighborGradientSumInc(n12, 3);
                                    

                                    g.FillRectangle(mygrey3, rect_grid[n22]);
                                    bytegrid[n22] = 3;
                                    AliveNeighborsIncBool(n22);
                                    isalive[n22] = true;

                                    
                                        NeighborGradientSumInc(n22, 3);
                                    

                                    g.FillRectangle(mygrey3, rect_grid[n32]);
                                    bytegrid[n32] = 3;
                                    AliveNeighborsIncBool(n32);
                                    isalive[n32] = true;

                                    
                                        NeighborGradientSumInc(n32, 3);
                                    

                                    g.FillRectangle(mygrey3, rect_grid[n42]);
                                    bytegrid[n42] = 3;
                                    AliveNeighborsIncBool(n42);
                                    isalive[n42] = true;
                                    
                                        NeighborGradientSumInc(n42, 3);
                                    
                                }
                                break;
                            case 4:
                                g.FillRectangle(full_black, rect_grid[n1]);
                                bytegrid[n1] = 4;
                               
                                AliveNeighborsIncBool(n1);
                                isalive[n1] = true;
                                
                                    NeighborGradientSumInc(n1, 4);
                                

                                g.FillRectangle(full_black, rect_grid[n2]);
                                bytegrid[n2] = 4;
                                
                                AliveNeighborsIncBool(n2);
                                isalive[n2] = true;
                                
                                    NeighborGradientSumInc(n2, 4);
                                

                                g.FillRectangle(full_black, rect_grid[n3]);
                                bytegrid[n3] = 4;
                                
                                AliveNeighborsIncBool(n3);
                                isalive[n3] = true;
                                
                                    NeighborGradientSumInc(n3, 4);
                                

                                g.FillRectangle(full_black, rect_grid[n4]);
                                bytegrid[n4] = 4;
                                
                                AliveNeighborsIncBool(n4);
                                isalive[n4] = true;
                                
                                    NeighborGradientSumInc(n4, 4);

                                if (n1 != n12)
                                {
                                    g.FillRectangle(full_black, rect_grid[n12]);
                                    bytegrid[n12] = 4;

                                    AliveNeighborsIncBool(n12);
                                    isalive[n12] = true;

                                    NeighborGradientSumInc(n12, 4);


                                    g.FillRectangle(full_black, rect_grid[n22]);
                                    bytegrid[n22] = 4;

                                    AliveNeighborsIncBool(n22);
                                    isalive[n22] = true;

                                    NeighborGradientSumInc(n22, 4);

                                    g.FillRectangle(full_black, rect_grid[n32]);
                                    bytegrid[n32] = 4;
                                    AliveNeighborsIncBool(n32);
                                    isalive[n32] = true;
                                    NeighborGradientSumInc(n32, 4);

                                    g.FillRectangle(full_black, rect_grid[n42]);
                                    bytegrid[n42] = 4;
                                    AliveNeighborsIncBool(n42);
                                    isalive[n42] = true;
                                    NeighborGradientSumInc(n42, 4);
                                }
                                break;

                            default:
                                break;
                        }

                    
                }

            }
        }
        private void Randomize()
        {

            Random rnd = new Random();

                for (int i = 0; i < cell_count_x*cell_count_y; i++)
                {
                    switch (rnd.Next(0, 5))
                    {
                        case 0:
                            g.FillRectangle(dead_white, rect_grid[i]);
                            bytegrid[i] = 0;
                            isalive[i] = false;

                            break;
                        case 1:
                            g.FillRectangle(mygrey1, rect_grid[i]);
                            bytegrid[i] = 1;
                            ModifiedButtonIncGeneralized(i);


                        break;
                        case 2:
                            g.FillRectangle(mygrey2, rect_grid[i]);
                            bytegrid[i] = 2;
                            ModifiedButtonIncGeneralized(i, 2);
                        break;
                        case 3:
                            g.FillRectangle(mygrey3, rect_grid[i]);
                            bytegrid[i] = 3;
                        ModifiedButtonIncGeneralized(i, 3);
                        break;
                        case 4:
                            g.FillRectangle(full_black, rect_grid[i]);
                            bytegrid[i] = 4;
                        ModifiedButtonIncGeneralized(i, 4);
                        break;

                        default:
                            break;
                    }

                }
        }
    }
}
