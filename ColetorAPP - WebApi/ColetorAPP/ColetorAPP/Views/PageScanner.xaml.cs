﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ColetorAPP.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ColetorAPP.Models;
using Xamarin.Essentials;
using Rg.Plugins.Popup.Services;
using ColetorAPP.Views;
using Xamarin.KeyboardHelper;

namespace ColetorAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageScanner : ContentPage
    {
        public string quant;
        int resultado = 1;
        public string codigo_barra;
        public PageScanner()
        {

            InitializeComponent();
            this.Appearing += MainPage_Appearing;
            this.Disappearing += MainPage_Disappearing;

            bt_focus.Clicked += bt_focus_Clicked;

        }
        void bt_focus_Clicked(object sender, EventArgs e)
        {
            txt_qtde.Focus();
        }



        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void MainPage_Disappearing(object sender, EventArgs e)
        {
            SoftKeyboard.Current.VisibilityChanged -= Current_VisibilityChanged;

        }

        private void MainPage_Appearing(object sender, EventArgs e)
        {
            SoftKeyboard.Current.VisibilityChanged += Current_VisibilityChanged;
            txt_qtde.Focus();
        }

        private void Current_VisibilityChanged(SoftKeyboardEventArgs e)
        {
            if (e.IsVisible)
            {
                // do your things

            }
            else
            {
                // do your things

            }
        }

        private void button2_clicked(object sender, EventArgs e)
        {
            txt_qtde.Focus();
        }

        private async void bt_ScannerAutomatico(object sender, EventArgs e) {
            //=> 
            while (resultado == 1)
            {
                await ScannerAutomatico();
            }
            //MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            //p.Detail = new NavigationPage(new PageHome());
            //await Navigation.PushModalAsync(new PageScanner());
        }
        private async Task ScannerAutomatico()
        {
            var scanner = DependencyService.Get<IQrCodeScanningService>();
            var result = await scanner.ScanAsync();
            try
            {
                if (!string.IsNullOrEmpty(result))
                {
                    resultado = 1;                    
                    var QrCode = result;                    
                    Vibration.Vibrate();
                    var duration = TimeSpan.FromSeconds(1);
                    Vibration.Vibrate(duration);

                    Produto nota = new Produto();
                    nota.Nome = QrCode.ToString();
                    nota.Setor = "teste";
                    nota.Quantidade = 1;
                    //nota.Favorito = swFavorito.IsToggled;
                    ServicesDBProduto dBNotas = new ServicesDBProduto(App.DbPath);

                    dBNotas.Inserir(nota);
                    DependencyService.Get<IMessage>().ShortAlert("Código: " + QrCode.ToString() + " \n Quantidade adicionada: 1");
               
                }
                else
                {
                    resultado = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        private async Task ScannerManual()
        {
            
            var scanner = DependencyService.Get<IQrCodeScanningService>();
            var result = await scanner.ScanAsync();
            try
            {
                if (!string.IsNullOrEmpty(result))
                {
                    resultado = 1;
                    var QrCode = result;
                    codigo_barra = QrCode;

                    Vibration.Vibrate();
                    var duration = TimeSpan.FromSeconds(1);
                    Vibration.Vibrate(duration);
                }
                else
                {
                    //await Navigation.PushModalAsync(new PageScanner());
                    resultado = 0;
                    txt_qtde.Focus();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
            SoftKeyboard.Current.VisibilityChanged += Current_VisibilityChanged;
            txt_qtde.Focus();
        }

        private async void bt_ScannerManual(object sender, EventArgs e)
        {
            await ScannerManual();
            bt_focus.Clicked += bt_focus_Clicked;
            this.Appearing += MainPage_Appearing;
            SoftKeyboard.Current.VisibilityChanged += Current_VisibilityChanged;
            txt_qtde.Focus();
            txt_qtde.Focus();
            txt_qtde.IsEnabled = true;


            if (!string.IsNullOrEmpty(codigo_barra))
            {

                base.OnAppearing();
                this.Appearing += MainPage_Appearing;
                this.Disappearing += MainPage_Disappearing;
                //base.Appearing += (object sender1, EventArgs e1) => txt_qtde.Focus();
                //txt_qtde.IsVisible = true;
                bt_gravarbanco.IsVisible = true;
                txt_qtde.Focus();
                txt_qtde.IsEnabled = true;
                this.Appearing += MainPage_Appearing;
                SoftKeyboard.Current.VisibilityChanged += Current_VisibilityChanged;
                txt_qtde.Focus();
                bt_focus.Clicked += bt_focus_Clicked;


            }
            this.Appearing += MainPage_Appearing;
            SoftKeyboard.Current.VisibilityChanged += Current_VisibilityChanged;
            txt_qtde.Focus();
            bt_focus.Clicked += bt_focus_Clicked;
        }
        private void Gravar_banco(object sender, EventArgs e)
        {
            Produto nota = new Produto();
            nota.Nome = codigo_barra;
            nota.Setor = "teste";
            nota.Quantidade = Int32.Parse(txt_qtde.Text);
            ServicesDBProduto dBNotas = new ServicesDBProduto(App.DbPath);
            dBNotas.Inserir(nota);
            DependencyService.Get<IMessage>().ShortAlert("Código: " + codigo_barra + " \n Quantidade adicionada: " + txt_qtde.Text);
            //txt_qtde.Text = "";
            //txt_qtde.IsVisible = false;
            //bt_gravarbanco.IsVisible = false;
            //txt_qtde.Focus();
        }
    }
}