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
        private ObservableCollection<TextBox> m_textBoxesCollection;
        private Command m_addEntry;
        private TextBox m_newTextBox;
        private ObservableCollection<string> m_entries;
        private string m_newEntry;

        public MainVM()
        {
            TextBoxesCollection = new ObservableCollection<TextBox>();
            Entries = new ObservableCollection<string>();
        }

        public ObservableCollection <TextBox> TextBoxesCollection
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

        public TextBox NewTextBox
        {
            get
            {
                return m_newTextBox;
            }
            set
            {
                m_newTextBox = value;
                RaiseEvent("NewTextBox");
            }
        }

        public string NewEntry
        {
            get
            {
                return m_newEntry;
            }
            set
            {
                m_newEntry = value;
                RaiseEvent("NewEntry");
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
            TextBoxesCollection.Add(new TextBox());
            var list = TextBoxesCollection;
            Entries.Add(NewEntry);
        }
    }
}
