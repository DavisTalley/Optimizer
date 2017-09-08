using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductionPlanDisplay.Logger
{
    public sealed class ListBoxLogger : IDisposable
    {
        private const string DEFAULT_MESSAGE_FORMAT = "{0} [{5}] : {8}";
        private const int DEFAULT_MAX_LINES_IN_LISTBOX = 2000;

        private bool _disposed;
        private ListBox _listBox;
        private string _messageFormat;
        private int _maxEntriesInListBox;
        private bool _canAdd;

        private void OnHandleCreated(object sender, EventArgs e)
        {
            _canAdd = true;
        }
        private void OnHandleDestroyed(object sender, EventArgs e)
        {
            _canAdd = false;
        }
        private void DrawItemHandler(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();

                LogEvent logEvent = ((ListBox)sender).Items[e.Index] as LogEvent;

                // SafeGuard against wrong configuration of list box
                if (logEvent == null)
                {
                    logEvent = new LogEvent(LogLevel.Critical, ((ListBox)sender).Items[e.Index].ToString());
                }

                Color color;
                switch (logEvent.Level)
                {
                    case LogLevel.Critical:
                        color = Color.White;
                        break;
                    case LogLevel.Error:
                        color = Color.Red;
                        break;
                    case LogLevel.Warning:
                        color = Color.Goldenrod;
                        break;
                    case LogLevel.Info:
                        color = Color.Green;
                        break;
                    case LogLevel.Verbose:
                        color = Color.Blue;
                        break;
                    default:
                        color = Color.Black;
                        break;
                }

                if (logEvent.Level == LogLevel.Critical)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
                }
                e.Graphics.DrawString(FormatALogEventMessage(logEvent, _messageFormat), new Font("Lucida Console", 8.25f, FontStyle.Regular), new SolidBrush(color), e.Bounds);
            }
        }
        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.C))
            {
                CopyToClipboard();
            }
        }
        private void CopyMenuOnClickHandler(object sender, EventArgs e)
        {
            CopyToClipboard();
        }
        private void CopyMenuPopupHandler(object sender, EventArgs e)
        {
            ContextMenu menu = sender as ContextMenu;
            if (menu != null)
            {
                menu.MenuItems[0].Enabled = (_listBox.SelectedItems.Count > 0);
            }
        }

        private class LogEvent
        {
            public LogEvent(LogLevel level, string message)
            {
                EventTime = DateTime.Now;
                Level = level;
                Message = message;
            }

            public readonly DateTime EventTime;

            public readonly LogLevel Level;
            public readonly string Message;
        }
        private void WriteEvent(LogEvent logEvent)
        {
            if ((logEvent != null) && (_canAdd))
            {
                _listBox.BeginInvoke(new AddALogEntryDelegate(AddALogEntry), logEvent);
            }
        }
        private delegate void AddALogEntryDelegate(object item);
        private void AddALogEntry(object item)
        {
            _listBox.Items.Add(item);

            if (_listBox.Items.Count > _maxEntriesInListBox)
            {
                _listBox.Items.RemoveAt(0);
            }

            if (!Paused) _listBox.TopIndex = _listBox.Items.Count - 1;
        }
        private string LevelName(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Critical: return "Critical";
                case LogLevel.Error: return "Error";
                case LogLevel.Warning: return "Warning";
                case LogLevel.Info: return "Info";
                case LogLevel.Verbose: return "Verbose";
                case LogLevel.Debug: return "Debug";
                default: return $"<value={(int)level}>";
            }
        }
        private string FormatALogEventMessage(LogEvent logEvent, string messageFormat)
        {
            string message = logEvent.Message;
            if (message == null) { message = "<NULL>"; }
            return string.Format(messageFormat,
                /* {0} */ logEvent.EventTime.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                /* {1} */ logEvent.EventTime.ToString("yyyy-MM-dd HH:mm:ss"),
                /* {2} */ logEvent.EventTime.ToString("yyyy-MM-dd"),
                /* {3} */ logEvent.EventTime.ToString("HH:mm:ss.fff"),
                /* {4} */ logEvent.EventTime.ToString("HH:mm:ss"),

                /* {5} */ LevelName(logEvent.Level)[0],
                /* {6} */ LevelName(logEvent.Level),
                /* {7} */ (int)logEvent.Level,

                /* {8} */ message);
        }
        private void CopyToClipboard()
        {
            if (_listBox.SelectedItems.Count > 0)
            {
                StringBuilder selectedItemsAsRtfText = new StringBuilder();
                selectedItemsAsRtfText.AppendLine(@"{\rtf1\ansi\deff0{\fonttbl{\f0\fcharset0 Courier;}}");
                selectedItemsAsRtfText.AppendLine(@"{\colortbl;\red255\green255\blue255;\red255\green0\blue0;\red218\green165\blue32;\red0\green128\blue0;\red0\green0\blue255;\red0\green0\blue0}");
                foreach (LogEvent logEvent in _listBox.SelectedItems)
                {
                    selectedItemsAsRtfText.AppendFormat(@"{{\f0\fs16\chshdng0\chcbpat{0}\cb{0}\cf{1} ", (logEvent.Level == LogLevel.Critical) ? 2 : 1, (logEvent.Level == LogLevel.Critical) ? 1 : ((int)logEvent.Level > 5) ? 6 : ((int)logEvent.Level) + 1);
                    selectedItemsAsRtfText.Append(FormatALogEventMessage(logEvent, _messageFormat));
                    selectedItemsAsRtfText.AppendLine(@"\par}");
                }
                selectedItemsAsRtfText.AppendLine(@"}");
                System.Diagnostics.Debug.WriteLine(selectedItemsAsRtfText.ToString());
                Clipboard.SetData(DataFormats.Rtf, selectedItemsAsRtfText.ToString());
            }

        }

        public ListBoxLogger(ListBox listBox) : this(listBox, DEFAULT_MESSAGE_FORMAT, DEFAULT_MAX_LINES_IN_LISTBOX) { }
        public ListBoxLogger(ListBox listBox, string messageFormat) : this(listBox, messageFormat, DEFAULT_MAX_LINES_IN_LISTBOX) { }
        public ListBoxLogger(ListBox listBox, string messageFormat, int maxLinesInListbox)
        {
            _disposed = false;

            _listBox = listBox;
            _messageFormat = messageFormat;
            _maxEntriesInListBox = maxLinesInListbox;

            Paused = false;

            _canAdd = listBox.IsHandleCreated;

            _listBox.SelectionMode = SelectionMode.MultiExtended;

            _listBox.HandleCreated += OnHandleCreated;
            _listBox.HandleDestroyed += OnHandleDestroyed;
            _listBox.DrawItem += DrawItemHandler;
            _listBox.KeyDown += KeyDownHandler;

            MenuItem[] menuItems = new MenuItem[] { new MenuItem("Copy", CopyMenuOnClickHandler) };
            _listBox.ContextMenu = new ContextMenu(menuItems);
            _listBox.ContextMenu.Popup += CopyMenuPopupHandler;

            _listBox.DrawMode = DrawMode.OwnerDrawFixed;
        }

        public void Log(string message) { Log(LogLevel.Debug, message); }
        public void Log(string format, params object[] args) { Log(LogLevel.Debug, (format == null) ? null : string.Format(format, args)); }
        public void Log(LogLevel level, string format, params object[] args) { Log(level, (format == null) ? null : string.Format(format, args)); }
        public void Log(LogLevel level, string message)
        {
            WriteEvent(new LogEvent(level, message));
        }

        public bool Paused { get; set; }

        ~ListBoxLogger()
        {
            if (!_disposed)
            {
                Dispose(false);
                _disposed = true;
            }
        }
        /// <summary>
        /// Perform cleanup
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
                _disposed = true;
            }
        }
        /// <summary>
        /// Complete list box clean up for proper Log viewer disposal 
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {

            if (disposing && _listBox != null)
            {
                _canAdd = false;

                _listBox.HandleCreated -= OnHandleCreated;
                _listBox.HandleCreated -= OnHandleDestroyed;
                _listBox.DrawItem -= DrawItemHandler;
                _listBox.KeyDown -= KeyDownHandler;

                _listBox.ContextMenu.MenuItems.Clear();
                _listBox.ContextMenu.Popup -= CopyMenuPopupHandler;
                _listBox.ContextMenu = null;

                _listBox.Items.Clear();
                _listBox.DrawMode = DrawMode.Normal;
                _listBox = null;
            }
        }
    }

}
