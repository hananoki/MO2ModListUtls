using HananokiLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MO2ModListUtls {

	public partial class MainForm : Form {


		void rollbackWindow() {
			//Location = new Point( m_config.x, m_config.y );
			Width = m_config.width;
			Height = m_config.height;
		}


		void backupWindow() {
			m_config.x = Location.X;
			m_config.y = Location.Y;
			m_config.width = Width;
			m_config.height = Height;
		}

		int oldTopIndex;

		void initTimerProcess() {
			timer2 = new Timer();
			timer2.Tick += new EventHandler( ( s, ee ) => {
				//toolStripStatusLabel1.Text = "";
				//toolStripStatusLabel1.Image = null;
				//timer.Stop();
				if( listView1.TopItem.Index == listView2.TopItem.Index ) return;

				if( oldTopIndex != listView1.TopItem.Index ) {
					listView2.EnsureVisible( listView2.Items.Count - 2 );
					listView2.EnsureVisible( listView1.TopItem.Index );
				}
				else {

					listView1.EnsureVisible( listView1.Items.Count - 2 );
					listView1.EnsureVisible( listView2.TopItem.Index );

				}

				//現在の位置を保存

				oldTopIndex = listView1.TopItem.Index;

			} );
			timer2.Interval = 30;

			timer2.Enabled = true;
		}

		List<string> requiredMod=new List<string>();

		void initListView( ref List<LVItem> items, ListView listview, string fileName, bool req=false ) {
			var aa = File.ReadAllLines( fileName );
			items = new List<LVItem>( aa.Length );

			int i = 0;
			foreach( var s in aa.Reverse() ) {

				if( string.IsNullOrEmpty( s ) ) continue;
				if( s[ 0 ] == '#' ) continue;
				if( s[ 0 ] == '*' ) {
					if( req ) {
						requiredMod.Add( s );
					}
					continue;
				}

				LVItem ii = new LVItem();

				var newItem = new ListViewItem( new string[] { s.Remove( 0, 1 ) } );
				newItem.Checked = true;
				if( s[ 0 ] == '+' ) {
					newItem.Checked = true;
				}
				else {
					newItem.Checked = false;
				}
				ii.item = newItem;

				if( i.Has( 0x01 ) ) {
					newItem.BackColor = Helper.LVBKColor;
				}
				else {
					newItem.BackColor = SystemColors.Window;
				}

				items.Add( ii );
				i++;
			}
			listview.VirtualListSize = items.Count;
			listview.Columns[ 0 ].Width = listview.Width - 4;
			listview.Columns[ 0 ].Text = $"{fileName}: ({items.Count})";
		}


	} // class
}
