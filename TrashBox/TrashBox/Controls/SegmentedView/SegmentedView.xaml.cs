using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace TrashBox.Controls.SegmentedView
{
    public partial class SegmentedView
    {
        #region Bindable Properties

        #region Orientation Property

        public static readonly BindableProperty OrientationProperty = BindableProperty.Create(
            nameof(Orientation),
            typeof(Orientation),
            typeof(SegmentedView),
            Orientation.Horizontal,
            propertyChanged: OnSegmentedViewPropertyChanged);

        public Orientation Orientation
        {
            get => (Orientation) GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        #endregion Orientation Property

        #region ItemsSource Property

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IEnumerable<SegmentedViewItem>),
            typeof(SegmentedView),
            propertyChanged: OnItemsSourcePropertyChanged);

        public IEnumerable<SegmentedViewItem> ItemsSource
        {
            get => (IEnumerable<SegmentedViewItem>) GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        private static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is SegmentedView view) || !(newValue is IEnumerable<SegmentedViewItem> itemsSource))
            {
                return;
            }

            view._innerItemsSource = itemsSource.Select(item => new InnerSegmentedViewItem {SegmentedViewItem = item})
                .ToList();

            if (view.SelectedItem is { } selectedItem &&
                view._innerItemsSource.FirstOrDefault(i => i.SegmentedViewItem == selectedItem) is { } innerItem)
            {
                innerItem.IsSelected = true;

                view.ChangeSelection(innerItem);
            }

            view.DrawContent();
        }

        #endregion ItemsSource Property

        #region IsNullableSelectionSupported Property

        public static readonly BindableProperty IsNullableSelectionSupportedProperty = BindableProperty.Create(
            nameof(IsNullableSelectionSupported),
            typeof(bool),
            typeof(SegmentedView),
            true);

        public bool IsNullableSelectionSupported
        {
            get => (bool) GetValue(IsNullableSelectionSupportedProperty);
            set => SetValue(IsNullableSelectionSupportedProperty, value);
        }

        #endregion IsNullableSelectionSupported Property

        #region SelectedItem Property

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
            nameof(SelectedItem),
            typeof(SegmentedViewItem),
            typeof(SegmentedView),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnSelectedItemPropertyChanged);

        public SegmentedViewItem SelectedItem
        {
            get => (SegmentedViewItem) GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        private static void OnSelectedItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is SegmentedView view) || !(view.ItemsSource is { }))
            {
                return;
            }

            if (newValue is SegmentedViewItem newItem &&
                view._innerItemsSource.FirstOrDefault(i => i.SegmentedViewItem == newItem) is { } currentSelection)
            {
                currentSelection.IsSelected = true;

                view.ChangeSelection(currentSelection);
            }
            else
            {
                if (view.IsNullableSelectionSupported &&
                    oldValue is SegmentedViewItem oldItem &&
                    view._innerItemsSource.FirstOrDefault(i => i.SegmentedViewItem == oldItem) is { })
                {
                    view.ChangeSelection(null);
                }
                else if (newValue == null && oldValue is SegmentedViewItem oldSelection)
                {
                    view.SelectedItem = oldSelection;
                }
            }
        }

        #endregion SelectedItem Property

        #region FontFamily Property

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            nameof(FontFamily),
            typeof(string),
            typeof(SegmentedView));

        public string FontFamily
        {
            get => (string) GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        #endregion FontFamily Property

        #region FontSize Property

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            nameof(FontSize),
            typeof(double),
            typeof(SegmentedView));

        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            get => (double) GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        #endregion FontSize Property

        #region FontAttributes Property

        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create(
            nameof(FontAttributes),
            typeof(FontAttributes),
            typeof(SegmentedView),
            FontAttributes.None);

        public FontAttributes FontAttributes
        {
            get => (FontAttributes) GetValue(FontAttributesProperty);
            set => SetValue(FontAttributesProperty, value);
        }

        #endregion FontAttributes Property

        #region TextColor Property

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(SegmentedView),
            propertyChanged: OnSegmentedViewPropertyChanged);

        public Color TextColor
        {
            get => (Color) GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        #endregion TextColor Property

        #region SelectedTextColor Property

        public static readonly BindableProperty SelectedTextColorProperty = BindableProperty.Create(
            nameof(SelectedTextColor),
            typeof(Color),
            typeof(SegmentedView),
            propertyChanged: OnSegmentedViewPropertyChanged);

        public Color SelectedTextColor
        {
            get => (Color) GetValue(SelectedTextColorProperty);
            set => SetValue(SelectedTextColorProperty, value);
        }

        #endregion SelectedTextColor Property

        #region BackgroundColor Property

        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
            nameof(BackgroundColor),
            typeof(Color),
            typeof(SegmentedView));

        public new Color BackgroundColor
        {
            get => (Color) GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        #endregion SelectedBackgroundColor Property

        #region SelectedBackgroundColor Property

        public static readonly BindableProperty SelectedBackgroundColorProperty = BindableProperty.Create(
            nameof(SelectedBackgroundColor),
            typeof(Color),
            typeof(SegmentedView));

        public Color SelectedBackgroundColor
        {
            get => (Color) GetValue(SelectedBackgroundColorProperty);
            set => SetValue(SelectedBackgroundColorProperty, value);
        }

        #endregion SelectedBackgroundColor Property

        #region CornerRadius Property

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
            nameof(CornerRadius),
            typeof(float),
            typeof(SegmentedView));

        public float CornerRadius
        {
            get => (float) GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        #endregion CornerRadius Property

        #region ItemCornerRadius Property

        public static readonly BindableProperty ItemCornerRadiusProperty = BindableProperty.Create(
            nameof(ItemCornerRadius),
            typeof(float),
            typeof(SegmentedView));

        public float ItemCornerRadius
        {
            get => (float) GetValue(ItemCornerRadiusProperty);
            set => SetValue(ItemCornerRadiusProperty, value);
        }

        #endregion ItemCornerRadius Property

        #endregion Bindable Properties

        private IList<InnerSegmentedViewItem> _innerItemsSource;

        public SegmentedView()
        {
            InitializeComponent();
        }

        private static void OnSegmentedViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is SegmentedView segmentedView))
            {
                return;
            }

            segmentedView.DrawContent();
        }

        private void DrawContent()
        {
            if (_innerItemsSource == null || !_innerItemsSource.Any())
            {
                return;
            }

            ContentGrid.Children.Clear();
            ContentGrid.RowDefinitions.Clear();
            ContentGrid.ColumnDefinitions.Clear();

            switch (Orientation)
            {
                case Orientation.Horizontal:
                {
                    ContentGrid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Star});

                    for (var i = 0; i < _innerItemsSource.Count; i++)
                    {
                        var item = _innerItemsSource[i];

                        ContentGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});

                        var view = CreateSegmentView(item);

                        ContentGrid.Children.Add(view, i, 0);
                    }

                    break;
                }
                case Orientation.Vertical:
                {
                    ContentGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});

                    for (var i = 0; i < _innerItemsSource.Count; i++)
                    {
                        var item = _innerItemsSource[i];

                        ContentGrid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Star});

                        var view = CreateSegmentView(item);

                        ContentGrid.Children.Add(view, 0, i);
                    }

                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (SelectedItem == null && !IsNullableSelectionSupported)
            {
                _innerItemsSource[0].IsSelected = true;

                SelectedItem = _innerItemsSource[0].SegmentedViewItem;
            }
        }

        private View CreateSegmentView(InnerSegmentedViewItem item)
        {
            var view = new SegmentView();
            view.SelectionChanged += OnSegmentViewSelectionChanged;

            view.SetBinding(SegmentView.SelectedBackgroundColorProperty,
                new Binding(nameof(SelectedBackgroundColor), source: this));
            view.SetBinding(SegmentView.SelectedTextColorProperty,
                new Binding(nameof(SelectedTextColor), source: this));
            view.SetBinding(SegmentView.TextColorProperty, new Binding(nameof(TextColor), source: this));
            view.SetBinding(SegmentView.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
            view.SetBinding(SegmentView.FontSizeProperty, new Binding(nameof(FontSize), source: this));
            view.SetBinding(SegmentView.FontAttributesProperty, new Binding(nameof(FontAttributes), source: this));
            view.SetBinding(SegmentView.CornerRadiusProperty, new Binding(nameof(ItemCornerRadius), source: this));
            view.SetBinding(SegmentView.IsNullableSelectionSupportedProperty,
                new Binding(nameof(IsNullableSelectionSupported), source: this));
            view.SetBinding(SegmentView.ItemProperty, new Binding(".", source: item));

            return view;
        }

        private void OnSegmentViewSelectionChanged(object sender, InnerSegmentedViewItem e)
        {
            if (e == null && !IsNullableSelectionSupported)
            {
                return;
            }

            SelectedItem = e?.SegmentedViewItem;
        }

        private void ChangeSelection(InnerSegmentedViewItem currentSelection)
        {
            if (_innerItemsSource == null || !_innerItemsSource.Any())
            {
                throw new Exception("Something went wrong :(");
            }

            //if (currentSelection == null)
            //{
            //    return;
            //}

            //if (!currentSelection.IsSelected)
            //{
            //    return;
            //}

            foreach (var item in _innerItemsSource)
            {
                if (!item.Equals(currentSelection))
                {
                    item.IsSelected = false;
                }
            }
        }
    }
}