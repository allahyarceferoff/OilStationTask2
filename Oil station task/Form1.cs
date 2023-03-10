using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;

namespace Oil_station_task
{
    public partial class Form1 : Form
    {
        List<Fuel> fuels = new List<Fuel>();
        List<Food> foods = new List<Food>();
        public Form1()
        {
            InitializeComponent();

            fuels.Add(new Fuel
            {
                Name = "AI92",
                Price = 1
            });
            fuels.Add(new Fuel
            {
                Name = "AI95",
                Price = 1.8
            });
            fuels.Add(new Fuel
            {
                Name = "AI98",
                Price = 2.3
            });
            fuels.Add(new Fuel
            {
                Name = "Diesel",
                Price = 0.8
            });
            fuels.Add(new Fuel
            {
                Name = "LPG",
                Price = 0.5
            });
            Food burger = new Food
            {
                FoodName = "Burger",
                FoodPrice = 5.6
            };
            Food hotdog = new Food
            {
                FoodName = "Hotdog",
                FoodPrice = 3.4
            };
            Food Nuggets = new Food
            {
                FoodName = "Nuggets",
                FoodPrice = 4.5
            };
            Food Cola = new Food
            {
                FoodName = "Coca Cola",
                FoodPrice = 2.3
            };
            Food pepsi = new Food
            {
                FoodName = "Pepsi",
                FoodPrice = 2.4
            };
            foods.Add(Cola); foods.Add(pepsi); foods.Add(Nuggets); foods.Add(hotdog); foods.Add(burger);
            guna2ComboBox1.DisplayMember = nameof(Fuel.Name);
            guna2ComboBox1.Items.AddRange(fuels.ToArray());
            guna2ComboBox1.SelectedIndex = 0;
            HotdogGunaCheckBox.Text = hotdog.FoodName;
            ColaGunaCheckBox.Text = Cola.FoodName;
            PepsiGunaCheckBox.Text = pepsi.FoodName;
            BurgerGunaCheckBox.Text = burger.FoodName;
            NuggetsGunaCheckBox.Text = Nuggets.FoodName;
            BurgerPriceLbl.Text = burger.FoodPrice.ToString();
            HotdogPriceLbl.Text = hotdog.FoodPrice.ToString();
            PepsiPricelbl.Text = pepsi.FoodPrice.ToString();
            ColaPriceLbl.Text = Cola.FoodPrice.ToString();
            NuggetPriceLbl.Text = Nuggets.FoodPrice.ToString();
        }
        private void MoneyGunaRadioBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Moneymaskedtxtb.Enabled = true;
            Litermaskedtxtb.Enabled = false;
        }

        private void LiterGunaRadioBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Litermaskedtxtb.Enabled = true;
            Moneymaskedtxtb.Enabled = false;
        }
        private void Moneymaskedtxtb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                label2.Text = Moneymaskedtxtb.Text;
            }
            catch (Exception)
            {

                throw;
            }
            CalculateGunaBtn.Enabled = true;
        }
        private void Litermaskedtxtb_TextChanged(object sender, EventArgs e)
        {
            var result1 = double.Parse(Litermaskedtxtb.Text) * double.Parse(fuelcostLbl.Text);
            label2.Text = result1.ToString();
            CalculateGunaBtn.Enabled = true;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExitBtn_MouseEnter(object sender, EventArgs e)
        {
            ExitBtn.BackColor = Color.Red;
        }

        private void ExitBtn_MouseLeave(object sender, EventArgs e)
        {
            ExitBtn.BackColor = Color.Silver;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = guna2ComboBox1.SelectedItem;
            for (int i = 0; i < fuels.Count; i++)
            {
                if (fuels[i].Name == result.ToString())
                {
                    fuelcostLbl.Text = fuels[i].Price.ToString();
                    break;
                }
            }
        }

        private void HotdogGunaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Hotdogquantity.Enabled = true;
        }
        private void BurgerGunaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Burgerquantity.Enabled = true;
        }
        private void ColaGunaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Colaquantity.Enabled = true;
        }
        private void PepsiGunaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Pepsiquantity.Enabled = true;
        }
        private void NuggetsGunaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Nuggetsquantity.Enabled = true;
        }
        double hotdogpay = 0;
        double burgerpay = 0;
        double pepsipay = 0;
        double colapay = 0;
        double nuggetspay = 0;
        double cafemoney = 0;
        private void Hotdogquantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hotdogpay = double.Parse(Hotdogquantity.Text) * double.Parse(HotdogPriceLbl.Text);
                cafemoney = hotdogpay + burgerpay + pepsipay + colapay + nuggetspay;
                cafemustpaylbl.Text = cafemoney.ToString();
            }
            catch (Exception)
            {
                hotdogpay = 0;
                cafemoney = hotdogpay + burgerpay + pepsipay + colapay + nuggetspay;
                cafemustpaylbl.Text = cafemoney.ToString();
            }
        }

        private void Burgerquantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                burgerpay = double.Parse(Burgerquantity.Text) * double.Parse(BurgerPriceLbl.Text);
                cafemoney = hotdogpay + burgerpay + pepsipay + colapay + nuggetspay;
                cafemustpaylbl.Text = cafemoney.ToString();
            }
            catch (Exception)
            {
                burgerpay = 0;
                cafemoney = hotdogpay + burgerpay + pepsipay + colapay + nuggetspay;
                cafemustpaylbl.Text = cafemoney.ToString();
            }
        }

        private void Colaquantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                colapay = double.Parse(Colaquantity.Text) * double.Parse(ColaPriceLbl.Text);
                cafemoney = hotdogpay + burgerpay + pepsipay + colapay + nuggetspay;
                cafemustpaylbl.Text = cafemoney.ToString();
            }
            catch (Exception)
            {
                colapay = 0;
                cafemoney = hotdogpay + burgerpay + pepsipay + colapay + nuggetspay;
                cafemustpaylbl.Text = cafemoney.ToString();
            }
        }

        private void Pepsiquantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pepsipay = double.Parse(Pepsiquantity.Text) * double.Parse(PepsiPricelbl.Text);
                cafemoney = hotdogpay + burgerpay + pepsipay + colapay + nuggetspay;
                cafemustpaylbl.Text = cafemoney.ToString();
            }
            catch (Exception)
            {
                pepsipay = 0;
                cafemoney = hotdogpay + burgerpay + pepsipay + colapay + nuggetspay;
                cafemustpaylbl.Text = cafemoney.ToString();
            }
        }

        private void Nuggetsquantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                nuggetspay = double.Parse(Nuggetsquantity.Text) * double.Parse(NuggetPriceLbl.Text);
                cafemoney = hotdogpay + burgerpay + pepsipay + colapay + nuggetspay;
                cafemustpaylbl.Text = cafemoney.ToString();
            }
            catch (Exception)
            {
                nuggetspay = 0;
                cafemoney = hotdogpay + burgerpay + pepsipay + colapay + nuggetspay;
                cafemustpaylbl.Text = cafemoney.ToString();
            }
        }

        private void cafemustpaylbl_TextChanged(object sender, EventArgs e)
        {
            if (double.Parse(cafemustpaylbl.Text) != 0)
            {
                CalculateGunaBtn.Enabled = true;
            }
            else
            {
                CalculateGunaBtn.Enabled = false;
            }
        }

        private void CalculateGunaBtn_Click(object sender, EventArgs e)
        {
            if (label2.Text != "" && cafemustpaylbl.Text != "")
            {
                var endpay = double.Parse(label2.Text) + double.Parse(cafemustpaylbl.Text);
                Calculatedpayment.Text = endpay.ToString()+ " AZN";
            }
            else if (label2.Text == "")
            {
                Calculatedpayment.Text = cafemustpaylbl.Text + " AZN";
            }
            else if (cafemustpaylbl.Text == "")
            {
                Calculatedpayment.Text = label2.Text + " AZN";
            }
        }
    }
}