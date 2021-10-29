using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MO2ModListUtls {
	public partial class Form1 : Form {

		MainForm m_parent;

		//LogWindow m_logWindow;




		public Form1( MainForm form ) {
			m_parent = form;
			InitializeComponent();
		}


		private void Form1_Load( object sender, EventArgs e ) {
			Font = SystemFonts.IconTitleFont;

			textBox_BaseModList.Text = MainForm.config.baseModListFilePath;
			textBox_ReplaceModList.Text = MainForm.config.replaceModListFilePath;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosing( object sender, FormClosingEventArgs e ) {
			MainForm.config.baseModListFilePath = textBox_BaseModList.Text;
			MainForm.config.replaceModListFilePath = textBox_ReplaceModList.Text;
		}


		private void button1_Click( object sender, EventArgs e ) {
			//Debug.Log( Helper.configPath );
			//LogWindow.Visible = true;
			//Program.Conv( config.filePathBase , config.filePathNext );


			//this.
			Close();
		}

		private void textBox1_DragEnter( object sender, DragEventArgs e ) {
			if( e.Data.GetDataPresent( DataFormats.FileDrop ) ) {

				// ドラッグ中のファイルやディレクトリの取得
				var drags = (string[]) e.Data.GetData( DataFormats.FileDrop );

				foreach( var d in drags ) {
					if( !File.Exists( d ) ) {
						// ファイル以外であればイベント・ハンドラを抜ける
						return;
					}
				}

				e.Effect = DragDropEffects.Link;
			}
		}

		private void textBox1_DragDrop( object sender, DragEventArgs e ) {
			// ドラッグ＆ドロップされたファイル
			string[] files = (string[]) e.Data.GetData( DataFormats.FileDrop );

			//listBox1.Items.AddRange( files ); // リストボックスに表示

			( (TextBox) sender ).Text = files[ 0 ];
			if( sender == textBox_BaseModList ) {
				MainForm.config.baseModListFilePath = textBox_BaseModList.Text;
			}
			if( sender == textBox_ReplaceModList ) {
				MainForm.config.replaceModListFilePath = textBox_ReplaceModList.Text;
			}
		}

		private void textBox1_DragEnter( object sender, EventArgs e ) {

		}


	}
}
