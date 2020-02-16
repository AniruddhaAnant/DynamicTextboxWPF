using DynamicTextBoxPoC.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DynamicTextBoxPoC
{
    public class MainVM : ViewModelBase
    {
        private ObservableCollection<TextBoxText> m_textBoxesCollection;
        private Command m_addEntry;
        private TextBox m_newTextBox;
        private ObservableCollection<string> m_entries;
        private string m_newEntry;

        public class TextBoxText
        {
            public string Text { get; set; }
        }
       
        public MainVM()
        {
            TextBoxesCollection = new ObservableCollection<TextBoxText>();
            Entries = new ObservableCollection<string>();
        }

        public ObservableCollection<TextBoxText> TextBoxesCollection
        {
            get
            {
                return m_textBoxesCollection;
            }
            set
            {
                m_textBoxesCollection = value;
                RaiseEvent("TextBoxesCollection");
            }
        }

        public ObservableCollection<string> Entries
        {
            get
            {
                return m_entries;
            }
            set
            {
                m_entries = value;
                RaiseEvent("Entries");
            }
        }

        public Command AddEntry
        {
            get
            {
                if (m_addEntry == null)
                {
                    m_addEntry = new Command(AddItem, CanAddItem);
                }
                return m_addEntry;
            }
        }

        private bool CanAddItem(object arg)
        {
            return true;
        }

        private void AddItem(object obj)
        {
            Entries.Clear(); 
            foreach(var tb in TextBoxesCollection)
            {
                Entries.Add(tb.Text);
            }
            TextBoxesCollection.Add(new TextBoxText());

        }
    }
}
