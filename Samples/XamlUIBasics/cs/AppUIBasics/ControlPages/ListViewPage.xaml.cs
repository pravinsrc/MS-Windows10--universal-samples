//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************
using AppUIBasics.Common;
using AppUIBasics.Data;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppUIBasics.ControlPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListViewPage : ItemsPageBase
    {
        public ListViewPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Items = ControlInfoDataSource.Instance.Groups.Take(3).SelectMany(g => g.Items).ToList();
        }

        private void ItemTemplate_Click(object sender, RoutedEventArgs e)
        {
            var template = (sender as FrameworkElement).Tag.ToString();
            Control1.ItemTemplate = (DataTemplate)this.Resources[template];
            itemTemplate.Text = template;
        }

        private void Control1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListView listView)
            {
                SelectionOutput.Text = string.Format("You have selected {0} item(s).", listView.SelectedItems.Count);
            }
        }

        private void Control1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClickOutput.Text = string.Format("You clicked {0}.", e.ClickedItem.ToString());
        }

        private void ItemClickCheckBox_Click(object sender, RoutedEventArgs e)
        {
            ClickOutput.Text = string.Empty;
        }

        private void FlowDirectionCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (Control1.FlowDirection == FlowDirection.LeftToRight)
            {
                Control1.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                Control1.FlowDirection = FlowDirection.LeftToRight;
            }
        }

        private void SelectionModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Control1 != null)
            {
                string colorName = e.AddedItems[0].ToString();
                switch (colorName)
                {
                    case "None":
                        Control1.SelectionMode = ListViewSelectionMode.None;
                        SelectionOutput.Text = string.Empty;
                        break;
                    case "Single":
                        Control1.SelectionMode = ListViewSelectionMode.Single;
                        break;
                    case "Multiple":
                        Control1.SelectionMode = ListViewSelectionMode.Multiple;
                        break;
                    case "Extended":
                        Control1.SelectionMode = ListViewSelectionMode.Extended;
                        break;
                }
            }
        }
    }
}
