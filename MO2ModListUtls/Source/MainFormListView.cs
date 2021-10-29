using HananokiLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MO2ModListUtls {

	public partial class MainForm : Form {

		void m_listView1_RetrieveVirtualItem( object sender, RetrieveVirtualItemEventArgs e ) {
			var view = (ListView) sender;
			if( view == listView1 ) {
				onRetrieveVirtualItem( e, m_itemsL );
			}
			else if( view == listView2 ) {
				onRetrieveVirtualItem( e, m_itemsR );
			}

		}

		void onRetrieveVirtualItem( RetrieveVirtualItemEventArgs e, List<LVItem> items ) {
			if( items.Count <= e.ItemIndex ) return;
			if( items == null ) return;

			e.Item = items[ e.ItemIndex ].item;
		}


		void listView2_MouseClick( object sender, MouseEventArgs e ) {
			var listview = (ListView) sender;
			var item = listview.GetItemAt( e.X, e.Y );

			//if( e.Button == MouseButtons.Right ) {
			//	var focusedItem = listview.FocusedItem;
			//	if( focusedItem != null && focusedItem.Bounds.Contains( e.Location ) ) {
			//		if( e.X < ( item.Bounds.Left + 16 ) ) {
			//			contextMenuStrip2.Show( Cursor.Position );
			//		}

			//		else {
			//			contextMenuStrip1.Show( Cursor.Position );
			//		}
			//	}
			//}
			//else {
			//var item = listview.GetItemAt( e.X, e.Y );
			if( item != null ) {
				if( e.X < ( item.Bounds.Left + 16 ) ) {
					item.invertChecked();
					//se_checked();
				}
			}
			//}
		}

	} // class
}
