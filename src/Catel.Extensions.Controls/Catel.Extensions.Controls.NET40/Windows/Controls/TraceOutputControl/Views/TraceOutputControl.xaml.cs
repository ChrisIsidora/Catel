﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TraceOutputControl.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2014 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Windows.Controls
{
    using System.Linq;
    using System.Windows;
    using MVVM.Views;
    using Logging;

    /// <summary>
    /// Interaction logic for TraceOutputControl.xaml
    /// </summary>
    public partial class TraceOutputControl : UserControl
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TraceOutputControl"/> class.
        /// </summary>
        public TraceOutputControl()
        {
            InitializeComponent();

            logListView.SelectionChanged += (sender, args) =>
            {
                var vm = ViewModel as TraceOutputViewModel;
                if (vm != null)
                {
                    vm.SelectedTraceEntries = logListView.SelectedItems.Cast<TraceEntry>().ToList();
                }
            };
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets whether the Catel logging should be ignored.
        /// </summary>
        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewModelWins)]
        public bool IgnoreCatelLogging
        {
            get { return (bool)GetValue(IgnoreCatelLoggingProperty); }
            set { SetValue(IgnoreCatelLoggingProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for IgnoreCatelLogging.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IgnoreCatelLoggingProperty =
            DependencyProperty.Register("IgnoreCatelLogging", typeof(bool), typeof(TraceOutputControl), new PropertyMetadata(true));

        /// <summary>
        /// Gets or sets the selected level.
        /// </summary>
        /// <value>The selected level.</value>
        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewModelWins)]
        public LogEvent SelectedLevel
        {
            get { return (LogEvent)GetValue(SelectedLevelProperty); }
            set { SetValue(SelectedLevelProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for SelectedLevel.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty SelectedLevelProperty =
            DependencyProperty.Register("SelectedLevel", typeof(LogEvent), typeof(TraceOutputControl), new PropertyMetadata(LogEvent.Debug));
        #endregion

        #region Methods
        /// <summary>
        /// Clears all messages from the control.
        /// </summary>
        public void Clear()
        {
            var vm = ViewModel as TraceOutputViewModel;
            if (vm != null)
            {
                vm.ClearOutput.Execute();
            }
        }
        #endregion
    }
}