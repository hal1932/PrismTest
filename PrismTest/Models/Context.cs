using Microsoft.Practices.Prism.Mvvm;
using System.Linq;

namespace PrismTest.Models
{
    class Context : BindableBase
    {
        public static Context Instance
        {
            get
            {
                if (_instance == null) _instance = new Context();
                return _instance;
            }
        }
        private static Context _instance;


        public Category[] CategoryArray
        {
            get { return _categoryArray; }
            set
            {
                _categoryArray = value;
                OnPropertyChanged("CategoryNameArray");

                if (value.Length > 0)
                {
                    CurrentCategoryIndex = 0;
                }
            }
        }
        private Category[] _categoryArray;


        public string[] CategoryNameArray
        {
            get { return CategoryArray.Select(item => item.Name).ToArray(); }
        }


        public string[] ItemArray
        {
            get { return _itemArray; }
            private set
            {
                _itemArray = value;
                OnPropertyChanged("ItemArray");
            }
        }
        private string[] _itemArray;


        public int CurrentCategoryIndex
        {
            get { return _currentCategoryIndex; }
            set
            {
                _currentCategoryIndex = value;
                OnPropertyChanged("CurrentCategoryIndex");

                if (_currentCategoryIndex < CategoryArray.Length)
                {
                    ItemArray = CategoryArray[value].ItemArray;
                    if (ItemArray != null)
                    {
                        CurrentItemIndex = 0;
                    }
                }
            }
        }
        private int _currentCategoryIndex;


        public int CurrentItemIndex
        {
            get { return _currentItemIndex; }
            set
            {
                _currentItemIndex = value;
                OnPropertyChanged("CurrentItemIndex");
                OnPropertyChanged("CurrentItemContent");
            }
        }
        private int _currentItemIndex;


        public string CurrentItemContent
        {
            get
            {
                if (_itemArray != null && _itemArray.Length > 0 && _currentItemIndex >= 0)
                {
                    return _itemArray[_currentItemIndex] + "_content";
                }
                return null;
            }
        }
    }
}
