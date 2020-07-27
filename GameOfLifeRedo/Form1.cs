using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GameOfLifeRedo
{
    public partial class Form1 : Form
    {
        
        readonly Pen blackpen = new Pen(Color.FromArgb(0, 0, 0));
        readonly Brush dead_white = new SolidBrush(Color.FromArgb(255,255,255));
        readonly Brush mygrey1 = new SolidBrush(Color.FromArgb(192, 192, 192));
        readonly Brush mygrey2 = new SolidBrush(Color.FromArgb(128, 128, 128));
        readonly Brush mygrey3 = new SolidBrush(Color.FromArgb(64, 64, 64));
        readonly Brush full_black = new SolidBrush(Color.FromArgb(0, 0, 0));
        Graphics g = null;
        bool isrunning = false;
        bool[] isalive;
        bool[] hasaliveneighbors;
        byte[] aliveneighbors_count;
        byte[] bytegrid;
        byte[] bytegrid_new;
        bool[] bytegrid_haschanged;
        int[,] neighbors;
        byte[] neighbors_gradient_sum;
        Rectangle[] rect_grid;
        enum Compass { N, E, S, W, NE, SE, SW, NW };

        static int top_left_x, top_left_y;
        static int bottom_right_x, bottom_right_y;
        

        static int cell_count_x, cell_count_y;
        const int sizeofcell = 4;
        

        enum general_state { initializing };

        public Form1()
        {
            InitializeComponent();

            InitVariables();
            InitNeighbors();

            

            AdjustWinFrame();
            g = GridColorFlowPanel.CreateGraphics();
            





        }

        private void GenerationTimer_Tick(object sender, EventArgs e)
        {
            RuleSetModifiedShelter();
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (!isrunning)
                StartGame();
            else
                PauseGame();
        }

        private void StartGame()
        {
            Start_Button.Text = "Pause";
            isrunning = true;
            
            GenerationTimer.Start();
        }
        private void PauseGame()
        {
            Start_Button.Text = "Start";
            GenerationTimer.Stop();
        }
        private void InitVariables()
        {
            top_left_x = GridColorFlowPanel.Location.X;
            top_left_y = GridColorFlowPanel.Location.Y;
            int tmp_bottom_right_x = top_left_x + GridColorFlowPanel.Width;
            int tmp_bottom_right_y = top_left_y + GridColorFlowPanel.Height - PanelBottom.Height;
            cell_count_x = (tmp_bottom_right_x - top_left_x - 1) / (sizeofcell + 1);
            
            cell_count_y = (tmp_bottom_right_y - top_left_y -1) / (sizeofcell+1);
            bottom_right_x = 1 + (sizeofcell + 1) * cell_count_x;
            bottom_right_y = 1 + (sizeofcell + 1) * cell_count_y;
            
            rect_grid = new Rectangle[cell_count_y * cell_count_x];
            for(int i = 0; i < cell_count_y; i++)
            {
                for(int j = 0; j < cell_count_x; j++)
                {
                    rect_grid[cell_count_x * i + j].X = top_left_x + j * sizeofcell + j + 1;
                    rect_grid[cell_count_x * i + j].Y = top_left_y + i * sizeofcell + i + 1;
                    rect_grid[cell_count_x * i + j].Size = new Size(sizeofcell,sizeofcell);
                }
            }
            bytegrid = new byte[cell_count_x * cell_count_y];

            
            isalive = new bool[cell_count_x * cell_count_y]; 
            hasaliveneighbors = new bool[cell_count_x * cell_count_y];
            aliveneighbors_count = new byte[cell_count_x * cell_count_y];
            bytegrid_new = new byte[cell_count_x * cell_count_y];
            bytegrid_haschanged = new bool[cell_count_x * cell_count_y];
            neighbors = new int[cell_count_x * cell_count_y,8];
            neighbors_gradient_sum=new byte[cell_count_x * cell_count_y];
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
                    else neighbors[i, (int)Compass.NE] = i - cell_count_x - cell_count_x-1;
                }
                else if (i < cell_count_x)
                {
                    neighbors[i, (int)Compass.NE] = i + cell_count_x * cell_count_y - cell_count_x + 1;
                }
                else neighbors[i, (int)Compass.NE] = i - cell_count_x + 1;

                if (cell_count_x %(i + 1) == 0)        //Handles SouthEast
                {
                    if (i == cell_count_x*cell_count_y -1)
                    {
                        neighbors[i, (int)Compass.SE] = 0;
                    }
                    else neighbors[i, (int)Compass.SE] = i + 1;
                }
                else if (i >= cell_count_x * cell_count_y - cell_count_x)
                {
                    neighbors[i, (int)Compass.SE] = i - cell_count_x * cell_count_y  + 1;
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
                    neighbors[i, (int)Compass.SW] = i - cell_count_x * cell_count_y - cell_count_x - 1;
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

                hasaliveneighbors[neighbors[buttonnumber, i]] = !(aliveneighbors_count[neighbors[buttonnumber, i]] == 0);
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
            if(white.Length != 0)
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
                g.DrawLine(new Pen(Color.Red), rect_grid[i].X-1, top_left_y, rect_grid[i].X-1, bottom_right_y-1);

            }
            g.DrawLine(new Pen(Color.Red), rect_grid[cell_count_x-1].X +sizeofcell, top_left_y, rect_grid[cell_count_x-1].X +sizeofcell, bottom_right_y-1);
            for (int i = 0; i < cell_count_y; i++)
            {
                g.DrawLine(new Pen(Color.Red), top_left_x, rect_grid[i*cell_count_x].Y-1, bottom_right_x-1, rect_grid[i * cell_count_x].Y-1);
            }
            g.DrawLine(new Pen(Color.Red), top_left_x, rect_grid[cell_count_y * cell_count_x-1].Y +sizeofcell, bottom_right_x - 1, rect_grid[cell_count_y * cell_count_x-1].Y +sizeofcell);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //InitVariables();
            AdjustWinFrame();


        }
        private void AdjustWinFrame()
        {
            
            this.Size = new Size(bottom_right_x+16, bottom_right_y + PanelBottom.Height + 39); //Offset from Form1 Size and InnerForm1 Size

        }

        private void FullSymmetric_Button_Click(object sender, EventArgs e)
        {
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
                    else if (neighbors_gradient_sum[i] < 8 || neighbors_gradient_sum[i] > 12) //Too small or too big
                    {

                        if (isalive[i])
                        {

                            bytegrid_new[i]--;
                        }
                    }
                    else if (neighbors_gradient_sum[i] > 8 && neighbors_gradient_sum[i] < 12) //Just right
                    {
                        if (bytegrid[i] != 4)
                        {

                            bytegrid_new[i]++;

                        }

                        isalive[i] = true;
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
                        isalive[i] = false;
                    }
                    
                        


                }
                else if (bytegrid_new[i] > bytegrid[i])
                {
                    bytegrid_haschanged[i] = true;
                    NeighborGradientSumInc(i);
                    isalive[i] = true;

                    

                }
                else
                {

                    bytegrid_haschanged[i] = false;
                }
            }
        }
        private void GenerateFullSymmetric() //Implement parity difference (middle line or 2 middle lines?)
        {
            byte range = 45;
            Random rnd = new Random();
            if(range >cell_count_x || range > cell_count_y)
            {
                MessageBox.Show("Range ist zu groß");
                return;
            }
            for (int i = 0; i < range; i++)
            {
                for (int j = 0; j < range - i; j++)
                {

                    if(cell_count_x % 2 != cell_count_y % 2)
                    {
                        MessageBox.Show("True Symmetric ist verschoben");
                        
                    }
                    if (cell_count_x % 2 == 0 && cell_count_y % 2 == 0)
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
                                for (int k = 0; k < 2; k++)
                                {
                                    NeighborGradientSumInc(n1);
                                }

                                g.FillRectangle(mygrey2, rect_grid[n2]);
                                bytegrid[n2] = 2;
                                AliveNeighborsIncBool(n2);
                                isalive[n2] = true;
                                for (int k = 0; k < 2; k++)
                                {
                                    NeighborGradientSumInc(n2);
                                }

                                g.FillRectangle(mygrey2, rect_grid[n3]);
                                bytegrid[n3] = 2;
                                AliveNeighborsIncBool(n3);
                                isalive[n3] = true;
                                for (int k = 0; k < 2; k++)
                                {
                                    NeighborGradientSumInc(n3);
                                }

                                g.FillRectangle(mygrey2, rect_grid[n4]);
                                bytegrid[n4] = 2;
                                AliveNeighborsIncBool(n4);
                                isalive[n4] = true;
                                for (int k = 0; k < 2; k++)
                                {
                                    NeighborGradientSumInc(n4);
                                }

                                if (n1 != n12)
                                {
                                    g.FillRectangle(mygrey2, rect_grid[n12]);
                                    bytegrid[n12] = 2;
                                    AliveNeighborsIncBool(n12);
                                    isalive[n12] = true;
                                    for (int k = 0; k < 2; k++)
                                    {
                                        NeighborGradientSumInc(n12);
                                    }

                                    g.FillRectangle(mygrey2, rect_grid[n22]);
                                    bytegrid[n22] = 2;
                                    AliveNeighborsIncBool(n22);
                                    isalive[n22] = true;
                                    for (int k = 0; k < 2; k++)
                                    {
                                        NeighborGradientSumInc(n22);
                                    }

                                    g.FillRectangle(mygrey2, rect_grid[n32]);
                                    bytegrid[n32] = 2;
                                    AliveNeighborsIncBool(n32);
                                    isalive[n32] = true;
                                    for (int k = 0; k < 2; k++)
                                    {
                                        NeighborGradientSumInc(n32);
                                    }

                                    g.FillRectangle(mygrey2, rect_grid[n42]);
                                    bytegrid[n42] = 2;
                                    AliveNeighborsIncBool(n42);
                                    isalive[n42] = true;
                                    for (int k = 0; k < 2; k++)
                                    {
                                        NeighborGradientSumInc(n42);
                                    }
                                }
                                break;
                            case 3:
                                g.FillRectangle(mygrey3, rect_grid[n1]);
                                bytegrid[n1] = 3;
                                AliveNeighborsIncBool(n1);
                                isalive[n1] = true;

                                for (int k = 0; k < 3; k++)
                                {
                                    NeighborGradientSumInc(n1);
                                }

                                g.FillRectangle(mygrey3, rect_grid[n2]);
                                bytegrid[n2] = 3;
                                AliveNeighborsIncBool(n2);
                                isalive[n2] = true;

                                for (int k = 0; k < 3; k++)
                                {
                                    NeighborGradientSumInc(n2);
                                }

                                g.FillRectangle(mygrey3, rect_grid[n3]);
                                bytegrid[n3] = 3;
                                AliveNeighborsIncBool(n3);
                                isalive[n3] = true;

                                for (int k = 0; k < 3; k++)
                                {
                                    NeighborGradientSumInc(n3);
                                }

                                g.FillRectangle(mygrey3, rect_grid[n4]);
                                bytegrid[n4] = 3;
                                AliveNeighborsIncBool(n4);
                                isalive[n4] = true;

                                for (int k = 0; k < 3; k++)
                                {
                                    NeighborGradientSumInc(n4);
                                }
                                if (n1 != n12)
                                {
                                    g.FillRectangle(mygrey3, rect_grid[n12]);
                                    bytegrid[n12] = 3;
                                    AliveNeighborsIncBool(n12);
                                    isalive[n12] = true;

                                    for (int k = 0; k < 3; k++)
                                    {
                                        NeighborGradientSumInc(n12);
                                    }

                                    g.FillRectangle(mygrey3, rect_grid[n22]);
                                    bytegrid[n22] = 3;
                                    AliveNeighborsIncBool(n22);
                                    isalive[n22] = true;

                                    for (int k = 0; k < 3; k++)
                                    {
                                        NeighborGradientSumInc(n22);
                                    }

                                    g.FillRectangle(mygrey3, rect_grid[n32]);
                                    bytegrid[n32] = 3;
                                    AliveNeighborsIncBool(n32);
                                    isalive[n32] = true;

                                    for (int k = 0; k < 3; k++)
                                    {
                                        NeighborGradientSumInc(n32);
                                    }

                                    g.FillRectangle(mygrey3, rect_grid[n42]);
                                    bytegrid[n42] = 3;
                                    AliveNeighborsIncBool(n42);
                                    isalive[n42] = true;
                                    for (int k = 0; k < 3; k++)
                                    {
                                        NeighborGradientSumInc(n42);
                                    }
                                }
                                break;
                            case 4:
                                g.FillRectangle(full_black, rect_grid[n1]);
                                bytegrid[n1] = 4;
                               
                                AliveNeighborsIncBool(n1);
                                isalive[n1] = true;
                                for (int k = 0; k < 4; k++)
                                {
                                    NeighborGradientSumInc(n1);
                                }

                                g.FillRectangle(full_black, rect_grid[n2]);
                                bytegrid[n2] = 4;
                                
                                AliveNeighborsIncBool(n2);
                                isalive[n2] = true;
                                for (int k = 0; k < 4; k++)
                                {
                                    NeighborGradientSumInc(n2);
                                }

                                g.FillRectangle(full_black, rect_grid[n3]);
                                bytegrid[n3] = 4;
                                
                                AliveNeighborsIncBool(n3);
                                isalive[n3] = true;
                                for (int k = 0; k < 4; k++)
                                {
                                    NeighborGradientSumInc(n3);
                                }

                                g.FillRectangle(full_black, rect_grid[n4]);
                                bytegrid[n4] = 4;
                                
                                AliveNeighborsIncBool(n4);
                                isalive[n4] = true;
                                for (int k = 0; k < 4; k++)
                                {
                                    NeighborGradientSumInc(n4);
                                }
                                if (n1 != n12)
                                {
                                    g.FillRectangle(full_black, rect_grid[n12]);
                                    bytegrid[n12] = 4;
                                   
                                    AliveNeighborsIncBool(n12);
                                    isalive[n12] = true;
                                    for (int k = 0; k < 4; k++)
                                    {
                                        NeighborGradientSumInc(n12);
                                    }

                                    g.FillRectangle(full_black, rect_grid[n22]);
                                    bytegrid[n22] = 4;
                                    
                                    AliveNeighborsIncBool(n22);
                                    isalive[n22] = true;
                                    for (int k = 0; k < 4; k++)
                                    {
                                        NeighborGradientSumInc(n22);
                                    }

                                    g.FillRectangle(full_black, rect_grid[n32]);
                                    bytegrid[n32] = 4;
                                    
                                    AliveNeighborsIncBool(n32);
                                    isalive[n32] = true;
                                    for (int k = 0; k < 4; k++)
                                    {
                                        NeighborGradientSumInc(n32);
                                    }

                                    g.FillRectangle(full_black, rect_grid[n42]);
                                    bytegrid[n42] = 4;
                                   
                                    AliveNeighborsIncBool(n42);
                                    isalive[n42] = true;
                                    for (int k = 0; k < 4; k++)
                                    {
                                        NeighborGradientSumInc(n42);
                                    }
                                }
                                break;

                            default:
                                break;
                        }

                    }
                }

            }
        }
    }
}
