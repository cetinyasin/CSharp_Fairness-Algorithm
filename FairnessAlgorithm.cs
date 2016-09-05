namespace FairnessFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

          float[] st_demand, st_weight, st_power;
          float cap = 0, n = 0, br = 0, init_cap = 0, remain_cap = 0;

        private void btn_Share_Click(object sender, EventArgs e)
        {
            try
            {
                st_demand = new float[4];
                st_weight = new float[4];
                st_power = new float[4];

                cap = float.Parse(tb_avaCap.Text);

                st_demand[0] = float.Parse(tb_st1_demand.Text);
                st_demand[1] = float.Parse(tb_st2_demand.Text);
                st_demand[2] = float.Parse(tb_st3_demand.Text);
                st_demand[3] = float.Parse(tb_st4_demand.Text);

                st_weight[0] = float.Parse(tb_st1_weight.Text);
                st_weight[1] = float.Parse(tb_st2_weight.Text);
                st_weight[2] = float.Parse(tb_st3_weight.Text);
                st_weight[3] = float.Parse(tb_st4_weight.Text);

                init_cap = cap;
                while (cap > 0)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        if (st_power[i] < st_demand[i])
                        {
                            n += st_weight[i];
                        }
                    }

                    br = cap / n;
                    cap = 0;
                    n = 0;

                    for (int i = 0; i <= 3; i++)
                    {
                        if (st_power[i] < st_demand[i])
                        {
                            st_power[i] += st_weight[i] * br;
                            if (st_power[i] > st_demand[i])
                            {
                                cap += st_power[i] - st_demand[i];
                                st_power[i] = st_demand[i];
                            }
                        }
                    }
                }
                remain_cap = init_cap - (st_power[0] + st_power[1] + st_power[2] + st_power[3]);

                lbl_st1_power.Text = st_power[0].ToString();
                lbl_st2_power.Text = st_power[1].ToString();
                lbl_st3_power.Text = st_power[2].ToString();
                lbl_st4_power.Text = st_power[3].ToString();
                lbl_remCap.Text = remain_cap.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
