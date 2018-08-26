using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace GenericDelegateEvent
{
    //http://w-tay.blogspot.com/2016/07/c-delegate-and-event.html
    public partial class Form1 : Form
    {
        //Generic
        GenericSetOne<int> _GenericSet;
        GenericSetTwo<int, Product> _GenericSetTwo;
        //Delegate
        public delegate void SDelegate();
        //DelegateEvent
        public event SDelegate _SDelegate;
        //Thread
        //要用這個Lock就會有順續
        static Object obj = new Object();
        Thread _t = null;
        Thread _t2 = null;
        Task[] taskArray = null;
        public delegate void UpdateUI(Control _Control, string Context);
        //public event UpdateUI _UpdateUIEvent;

        public Form1()
        {
            InitializeComponent();
        }

        public void UpdateText(Control _ct, string Context)
        {
            if (_ct.InvokeRequired)
            {
                UpdateUI _UpdateUI = new UpdateUI(UpdateText);
                // _UpdateUI.Invoke(_ct, Context);
                _ct.Invoke(_UpdateUI, _ct, Context);
            }
            else
            {
                tb_Context.Text += Context + " \r\n";
            }
        }

        void init()
        {
            _GenericSet = new GenericSetOne<int>();
            _GenericSetTwo = new GenericSetTwo<int, Product>();
        }

        void Sett()
        {
            for (int index = 0; index < 10; index++)
            {
                _GenericSet.Add(index);
            }

            for (int index = 0; index < 10; index++)
            {
                Product _pt = new Product();
                _pt.ItemNo = index + 1;
                _pt.Price = (float)(index + 1) * (float)(1.12);
                _pt.Name = "This is " + (index + 1).ToString() + "th Product";
                _GenericSetTwo.Add(index, _pt);
            }
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            tb_Context.Text = "";
            string Select = cb_Select.SelectedItem.ToString();
            UpdateText(this.tb_Context, Select);
            if (Select == "Generic" || Select == "Delegate" || Select == "DelegateEvent")
            {

                int DicAll = _GenericSetTwo.GetCount();
                int ListAll = _GenericSet.GetCount();
                for (int index = 0; index < ListAll; index++)
                {
                    int Result = _GenericSet.Get(index);
                    UpdateText(this.tb_Context, Result.ToString());
                }
                UpdateText(this.tb_Context, "--------------------------");
                for (int index = 0; index < ListAll; index++)
                {
                    Product Result = _GenericSetTwo.Get(index);
                    UpdateText(this.tb_Context, Result.ItemNo.ToString());
                    UpdateText(this.tb_Context, Result.Name.ToString());
                    UpdateText(this.tb_Context, Result.Price.ToString());
                }
            }
            else
            {
                if (Select == "Thread")
                {
                    // _t.Start();
                    // _t.Join();
                    // _t2.Start();
                    for (int i = 0; i < 10; i++)
                    {
                        _t = new Thread(NameThreadA);
                        _t.Start("This is _t " + i.ToString() + "th Thread");

                        _t2 = new Thread(NameThreadB);
                        _t2.Start("This is _t2 " + i.ToString() + "th Thread");
                    }

                }
                else if (Select == "ThreadPool")
                {
                    for (int i = 0; i < 10; i++)
                    {
                        object _oo = "This is " + i.ToString() + "th Thread";
                        ThreadPool.QueueUserWorkItem(new WaitCallback(NameThread), "This is " + i.ToString() + "th Thread");
                    }
                }
                else if (Select == "Task")
                {
                    taskArray = new Task[10];

                    for (int i = 0; i < 10; i++)
                    {
                        object oo = "This is taskA " + i.ToString() + "th Thread";
                        taskArray[i] = new Task(() => NameThread(oo));
                        taskArray[i].Start();
                     
                    }
                              
                }
            }
        }

        private void cb_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Select.SelectedItem.ToString() == "Generic")
            {
                init();
                Sett();
            }
            else if (cb_Select.SelectedItem.ToString() == "Delegate")
            {
                SDelegate _initDelegate = new SDelegate(init);
                SDelegate _SettDelegate = new SDelegate(Sett);
            }
            else if (cb_Select.SelectedItem.ToString() == "DelegateEvent")
            {
                _SDelegate += init;
                _SDelegate += Sett;
                _SDelegate.Invoke();
            }
            else if (cb_Select.SelectedItem.ToString() == "Thread")
            {
               
            }
            else if (cb_Select.SelectedItem.ToString() == "Task")
            {
              
            }
        }

        public void NameThread(object Context)
        {
            lock (obj)
            {
                UpdateText(this.tb_Context, Context.ToString());

            }
        }

        public void NameThreadA(object Context)
        {
            lock (obj)
            {
                UpdateText(this.tb_Context, Context.ToString());
               
            }
            _t2.Join();
        }

        public void NameThreadB(object Context)
        {
            lock (obj)
           {
                UpdateText(this.tb_Context, Context.ToString());
           }
        }



        public void ForThread()
        {
            lock (obj)
            {
                UpdateText(this.tb_Context, "For First");
                init();
                Sett();
                int DicAll = _GenericSetTwo.GetCount();
                int ListAll = _GenericSet.GetCount();
                for (int index = 0; index < ListAll; index++)
                {
                    int Result = _GenericSet.Get(index);
                    UpdateText(this.tb_Context, Result.ToString());
                }
                UpdateText(this.tb_Context, "--------------------------");
                for (int index = 0; index < ListAll; index++)
                {
                    Product Result = _GenericSetTwo.Get(index);
                    UpdateText(this.tb_Context, Result.ItemNo.ToString());
                    UpdateText(this.tb_Context, Result.Name.ToString());
                    UpdateText(this.tb_Context, Result.Price.ToString());
                }
            }
        }

        public void ForThread2()
        {
            lock (obj)
            {
                UpdateText(this.tb_Context, "For Second");
                //init();
                //Sett();
                int DicAll = _GenericSetTwo.GetCount();
                int ListAll = _GenericSet.GetCount();
                for (int index = 0; index < ListAll; index++)
                {
                    int Result = _GenericSet.Get(index);
                    UpdateText(this.tb_Context, Result.ToString());
                }
                UpdateText(this.tb_Context, "--------------------------");
                for (int index = 0; index < ListAll; index++)
                {
                    Product Result = _GenericSetTwo.Get(index);
                    UpdateText(this.tb_Context, Result.ItemNo.ToString());
                    UpdateText(this.tb_Context, Result.Name.ToString());
                    UpdateText(this.tb_Context, Result.Price.ToString());
                }
            }
        }

        public void ForTask()
        {
            UpdateText(this.tb_Context, "For First");
            init();
            Sett();
            int DicAll = _GenericSetTwo.GetCount();
            int ListAll = _GenericSet.GetCount();
            for (int index = 0; index < ListAll; index++)
            {
                int Result = _GenericSet.Get(index);
                UpdateText(this.tb_Context, Result.ToString());
            }
            UpdateText(this.tb_Context, "--------------------------");
            for (int index = 0; index < ListAll; index++)
            {
                Product Result = _GenericSetTwo.Get(index);
                UpdateText(this.tb_Context, Result.ItemNo.ToString());
                UpdateText(this.tb_Context, Result.Name.ToString());
                UpdateText(this.tb_Context, Result.Price.ToString());
            }
        }

        public void ForTask2()
        {

            UpdateText(this.tb_Context, "For Second");
            //init();
            //Sett();
            int DicAll = _GenericSetTwo.GetCount();
            int ListAll = _GenericSet.GetCount();
            for (int index = 0; index < ListAll; index++)
            {
                int Result = _GenericSet.Get(index);
                UpdateText(this.tb_Context, Result.ToString());
            }
            UpdateText(this.tb_Context, "--------------------------");
            for (int index = 0; index < ListAll; index++)
            {
                Product Result = _GenericSetTwo.Get(index);
                UpdateText(this.tb_Context, Result.ItemNo.ToString());
                UpdateText(this.tb_Context, Result.Name.ToString());
                UpdateText(this.tb_Context, Result.Price.ToString());

            }
        }

        public void ForThreadPool(object _a)
        {
            lock (obj)
            {
                init();
                Sett();
                int DicAll = _GenericSetTwo.GetCount();
                int ListAll = _GenericSet.GetCount();
                for (int index = 0; index < ListAll; index++)
                {
                    int Result = _GenericSet.Get(index);
                    UpdateText(this.tb_Context, Result.ToString());
                }
                UpdateText(this.tb_Context, "--------------------------");
                for (int index = 0; index < ListAll; index++)
                {
                    Product Result = _GenericSetTwo.Get(index);
                    UpdateText(this.tb_Context, Result.ItemNo.ToString());
                    UpdateText(this.tb_Context, Result.Name.ToString());
                    UpdateText(this.tb_Context, Result.Price.ToString());
                }
            }
        }
    }
}
