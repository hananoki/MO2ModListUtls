using HananokiLib;
using System;
using System.IO;
using System.Windows.Forms;


namespace MO2ModListUtls {
	static class Program {
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main( string[] args ) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );

			Helper._init();
			if( 0 < args.Length ) {
				Debug.Log( args[ 0 ] );
				Helper.s_appPath = args[ 0 ];
			}
			Application.Run( new MainForm() );
		}


		public static void Conv( string filePathBase, string filePathNext ) {
			var aa = File.ReadAllLines( filePathNext );
			var bb = File.ReadAllLines( filePathBase );



			for( int i = 0; i < aa.Length; i++ ) {
				var s = bb[ i ];
				if( string.IsNullOrEmpty( s ) ) continue;
				if( s[ 0 ] == '-' ) {
					var cc = s.ToCharArray();
					cc[ 0 ] = '+';

					bb[ i ] = new string( cc );
				}
			}

			for( int i = 0; i < aa.Length; i++ ) {
				var output = bb[ i ];
				if( output[ 0 ] == '#' ) continue;
				if( output[ 0 ] == '*' ) continue;

				bool find = false;
				for( int j = 0; j < aa.Length; j++ ) {
					var chk = aa[ j ];
					if( output == chk ) {
						find = true;
						break;
					}
				}
				if( !find ) {
					var cc = output.ToCharArray();
					cc[ 0 ] = '-';

					bb[ i ] = new string( cc );
				}
			}

			File.WriteAllLines( @"G:\Skyrim\MO2\profiles\new.txt", bb );
		}

	}
}
