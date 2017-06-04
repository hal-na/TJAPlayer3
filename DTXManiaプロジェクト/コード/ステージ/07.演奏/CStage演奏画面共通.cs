using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;
using System.Threading;
using SlimDX;
using SlimDX.Direct3D9;
using FDK;

namespace DTXMania
{
	/// <summary>
	/// 演奏画面の共通クラス (ドラム演奏画面, ギター演奏画面の継承元)
	/// </summary>
	internal abstract class CStage演奏画面共通 : CStage
	{
		// プロパティ

		public bool bAUTOでないチップが１つでもバーを通過した	// 誰も参照していない？？
		{
			get;
			protected set;
		}

		// メソッド

		#region [ t演奏結果を格納する_ドラム() ]
		public void t演奏結果を格納する_ドラム( out CScoreIni.C演奏記録 Drums )
		{
			Drums = new CScoreIni.C演奏記録();

			//if (  )
			{
				Drums.nスコア = (long) this.actScore.Get( E楽器パート.DRUMS );
				Drums.dbゲーム型スキル値 = CScoreIni.tゲーム型スキルを計算して返す( CDTXMania.DTX.LEVEL.Drums, CDTXMania.DTX.n可視チップ数.Drums, this.nヒット数_Auto含まない.Drums.Perfect, this.actCombo.n現在のコンボ数.Drums最高値, E楽器パート.DRUMS, bIsAutoPlay );
				Drums.db演奏型スキル値 = CScoreIni.t演奏型スキルを計算して返す( CDTXMania.DTX.n可視チップ数.Drums, this.nヒット数_Auto含まない.Drums.Perfect, this.nヒット数_Auto含まない.Drums.Great, this.nヒット数_Auto含まない.Drums.Good, this.nヒット数_Auto含まない.Drums.Poor, this.nヒット数_Auto含まない.Drums.Miss, E楽器パート.DRUMS, bIsAutoPlay );
				Drums.nPerfect数 = CDTXMania.ConfigIni.b太鼓パートAutoPlay ? this.nヒット数_Auto含む.Drums.Perfect : this.nヒット数_Auto含まない.Drums.Perfect;
				Drums.nGreat数 = CDTXMania.ConfigIni.b太鼓パートAutoPlay ? this.nヒット数_Auto含む.Drums.Great : this.nヒット数_Auto含まない.Drums.Great;
				Drums.nGood数 = CDTXMania.ConfigIni.b太鼓パートAutoPlay ? this.nヒット数_Auto含む.Drums.Good : this.nヒット数_Auto含まない.Drums.Good;
				Drums.nPoor数 = CDTXMania.ConfigIni.b太鼓パートAutoPlay ? this.nヒット数_Auto含む.Drums.Poor : this.nヒット数_Auto含まない.Drums.Poor;
				Drums.nMiss数 = CDTXMania.ConfigIni.b太鼓パートAutoPlay ? this.nヒット数_Auto含む.Drums.Miss : this.nヒット数_Auto含まない.Drums.Miss;
				Drums.nPerfect数_Auto含まない = this.nヒット数_Auto含まない.Drums.Perfect;
				Drums.nGreat数_Auto含まない = this.nヒット数_Auto含まない.Drums.Great;
				Drums.nGood数_Auto含まない = this.nヒット数_Auto含まない.Drums.Good;
				Drums.nPoor数_Auto含まない = this.nヒット数_Auto含まない.Drums.Poor;
				Drums.nMiss数_Auto含まない = this.nヒット数_Auto含まない.Drums.Miss;
                Drums.n連打数 = this.n合計連打数;
				Drums.n最大コンボ数 = this.actCombo.n現在のコンボ数.Drums最高値;
				Drums.n全チップ数 = CDTXMania.DTX.n可視チップ数.Drums;
				for ( int i = 0; i < (int) Eレーン.MAX;  i++ )
				{
					Drums.bAutoPlay[ i ] = bIsAutoPlay[ i ];
				}
				Drums.bTight = CDTXMania.ConfigIni.bTight;
				for ( int i = 0; i < 3; i++ )
				{
					Drums.bSudden[ i ] = CDTXMania.ConfigIni.bSudden[ i ];
					Drums.bHidden[ i ] = CDTXMania.ConfigIni.bHidden[ i ];
					Drums.eInvisible[ i ] = CDTXMania.ConfigIni.eInvisible[ i ];
					Drums.bReverse[ i ] = CDTXMania.ConfigIni.bReverse[ i ];
					Drums.eRandom[ i ] = CDTXMania.ConfigIni.eRandom[ i ];
					Drums.bLight[ i ] = CDTXMania.ConfigIni.bLight[ i ];
					Drums.bLeft[ i ] = CDTXMania.ConfigIni.bLeft[ i ];
					Drums.f譜面スクロール速度[ i ] = ( (float) ( CDTXMania.ConfigIni.n譜面スクロール速度[ i ] + 1 ) ) * 0.5f;
				}
				Drums.eDark = CDTXMania.ConfigIni.eDark;
				Drums.n演奏速度分子 = CDTXMania.ConfigIni.n演奏速度;
				Drums.n演奏速度分母 = 20;
				Drums.bSTAGEFAILED有効 = CDTXMania.ConfigIni.bSTAGEFAILED有効;
				Drums.eダメージレベル = CDTXMania.ConfigIni.eダメージレベル;
				Drums.b演奏にキーボードを使用した = this.b演奏にキーボードを使った.Drums;
				Drums.b演奏にMIDI入力を使用した = this.b演奏にMIDI入力を使った.Drums;
				Drums.b演奏にジョイパッドを使用した = this.b演奏にジョイパッドを使った.Drums;
				Drums.b演奏にマウスを使用した = this.b演奏にマウスを使った.Drums;
				Drums.nPerfectになる範囲ms = CDTXMania.nPerfect範囲ms;
				Drums.nGreatになる範囲ms = CDTXMania.nGreat範囲ms;
				Drums.nGoodになる範囲ms = CDTXMania.nGood範囲ms;
				Drums.nPoorになる範囲ms = CDTXMania.nPoor範囲ms;
				Drums.strDTXManiaのバージョン = CDTXMania.VERSION;
				Drums.最終更新日時 = DateTime.Now.ToString();
				Drums.Hash = CScoreIni.t演奏セクションのMD5を求めて返す( Drums );
                Drums.fゲージ = (float)this.actGauge.db現在のゲージ値.Taiko;
                if( !CDTXMania.ConfigIni.b太鼓パートAutoPlay )
                {
                    Drums.nハイスコア = CDTXMania.stage選曲.r確定されたスコア.譜面情報.nハイスコア; //2015.06.16 kairera0467 他難易度の上書き防止。
                    if( CDTXMania.stage選曲.r確定されたスコア.譜面情報.nハイスコア[ CDTXMania.stage選曲.n確定された曲の難易度 ] < (int)this.actScore.Get( E楽器パート.DRUMS ) )
                        Drums.nハイスコア[ CDTXMania.stage選曲.n確定された曲の難易度 ] = (int)this.actScore.Get( E楽器パート.DRUMS );
                }
			}
		}
		#endregion
		#region [ t演奏結果を格納する_太鼓() ]
		public void t演奏結果を格納する_太鼓( out CScoreIni.C演奏記録 Drums )
		{
			Drums = new CScoreIni.C演奏記録();

			//if ( CDTXMania.DTX.bチップがある.Drums )
			{
				Drums.nスコア = (long) this.actScore.Get( E楽器パート.DRUMS );
				Drums.dbゲーム型スキル値 = CScoreIni.tゲーム型スキルを計算して返す( CDTXMania.DTX.LEVEL.Drums, CDTXMania.DTX.n可視チップ数.Drums, this.nヒット数_Auto含まない.Drums.Perfect, this.actCombo.n現在のコンボ数.Drums最高値, E楽器パート.DRUMS, bIsAutoPlay );
				Drums.db演奏型スキル値 = CScoreIni.t演奏型スキルを計算して返す( CDTXMania.DTX.n可視チップ数.Drums, this.nヒット数_Auto含まない.Drums.Perfect, this.nヒット数_Auto含まない.Drums.Great, this.nヒット数_Auto含まない.Drums.Good, this.nヒット数_Auto含まない.Drums.Poor, this.nヒット数_Auto含まない.Drums.Miss, E楽器パート.DRUMS, bIsAutoPlay );
				Drums.nPerfect数 = this.nヒット数_Auto含まない.Taiko.Perfect;
				Drums.nGreat数 = this.nヒット数_Auto含まない.Taiko.Great;
				Drums.nGood数 = this.nヒット数_Auto含まない.Taiko.Good;
				Drums.nPoor数 = this.nヒット数_Auto含まない.Taiko.Poor;
				Drums.nMiss数 = this.nヒット数_Auto含まない.Taiko.Miss;
				Drums.nPerfect数_Auto含まない = this.nヒット数_Auto含まない.Taiko.Perfect;
				Drums.nGreat数_Auto含まない = this.nヒット数_Auto含まない.Taiko.Great;
				Drums.nGood数_Auto含まない = this.nヒット数_Auto含まない.Taiko.Good;
				Drums.nPoor数_Auto含まない = this.nヒット数_Auto含まない.Taiko.Poor;
				Drums.nMiss数_Auto含まない = this.nヒット数_Auto含まない.Taiko.Miss;
                Drums.n連打数 = this.n合計連打数;
				Drums.n最大コンボ数 = this.actCombo.n現在のコンボ数.Taiko最高値;
				Drums.n全チップ数 = CDTXMania.DTX.nノーツ数[ 3 ];
				for ( int i = 0; i < (int) Eレーン.MAX;  i++ )
				{
					Drums.bAutoPlay[ i ] = CDTXMania.ConfigIni.b太鼓パートAutoPlay;
				}
				Drums.bTight = CDTXMania.ConfigIni.bTight;
				for ( int i = 0; i < 3; i++ )
				{
					Drums.bSudden[ i ] = CDTXMania.ConfigIni.bSudden[ i ];
					Drums.bHidden[ i ] = CDTXMania.ConfigIni.bHidden[ i ];
					Drums.eInvisible[ i ] = CDTXMania.ConfigIni.eInvisible[ i ];
					Drums.bReverse[ i ] = CDTXMania.ConfigIni.bReverse[ i ];
					Drums.eRandom[ i ] = CDTXMania.ConfigIni.eRandom[ i ];
					Drums.bLight[ i ] = CDTXMania.ConfigIni.bLight[ i ];
					Drums.bLeft[ i ] = CDTXMania.ConfigIni.bLeft[ i ];
					Drums.f譜面スクロール速度[ i ] = ( (float) ( CDTXMania.ConfigIni.n譜面スクロール速度[ i ] + 1 ) ) * 0.5f;
				}
				Drums.eDark = CDTXMania.ConfigIni.eDark;
				Drums.n演奏速度分子 = CDTXMania.ConfigIni.n演奏速度;
				Drums.n演奏速度分母 = 20;
				Drums.bSTAGEFAILED有効 = CDTXMania.ConfigIni.bSTAGEFAILED有効;
				Drums.eダメージレベル = CDTXMania.ConfigIni.eダメージレベル;
				Drums.b演奏にキーボードを使用した = this.b演奏にキーボードを使った.Drums;
				Drums.b演奏にMIDI入力を使用した = this.b演奏にMIDI入力を使った.Drums;
				Drums.b演奏にジョイパッドを使用した = this.b演奏にジョイパッドを使った.Drums;
				Drums.b演奏にマウスを使用した = this.b演奏にマウスを使った.Drums;
				Drums.nPerfectになる範囲ms = CDTXMania.nPerfect範囲ms;
				Drums.nGreatになる範囲ms = CDTXMania.nGreat範囲ms;
				Drums.nGoodになる範囲ms = CDTXMania.nGood範囲ms;
				Drums.nPoorになる範囲ms = CDTXMania.nPoor範囲ms;
				Drums.strDTXManiaのバージョン = CDTXMania.VERSION;
				Drums.最終更新日時 = DateTime.Now.ToString();
				Drums.Hash = CScoreIni.t演奏セクションのMD5を求めて返す( Drums );
                Drums.fゲージ = (float)this.actGauge.db現在のゲージ値.Drums;
			}
		}
		#endregion

		// CStage 実装

		public override void On活性化()
		{
			listChip = CDTXMania.DTX.listChip;
			listWAV = CDTXMania.DTX.listWAV;

			this.eフェードアウト完了時の戻り値 = E演奏画面の戻り値.継続;
			this.n現在のトップChip = ( listChip.Count > 0 ) ? 0 : -1;
			this.L最後に再生したHHの実WAV番号 = new List<int>( 16 );
			this.n最後に再生したHHのチャンネル番号 = 0;
			this.n最後に再生した実WAV番号.Guitar = -1;
			this.n最後に再生した実WAV番号.Bass = -1;
			for ( int i = 0; i < 50; i++ )
			{
				this.n最後に再生したBGMの実WAV番号[ i ] = -1;
			}
			cInvisibleChip = new CInvisibleChip( CDTXMania.ConfigIni.nDisplayTimesMs, CDTXMania.ConfigIni.nFadeoutTimeMs );
			this.演奏判定ライン座標 = new C演奏判定ライン座標共通();
			for ( int k = 0; k < 4; k++ )
			{
				//for ( int n = 0; n < 5; n++ )
				//{
					this.nヒット数_Auto含まない[ k ] = new CHITCOUNTOFRANK();
					this.nヒット数_Auto含む[ k ] = new CHITCOUNTOFRANK();
				//}
				this.queWailing[ k ] = new Queue<CDTX.CChip>();
				this.r現在の歓声Chip[ k ] = null;
				cInvisibleChip.eInvisibleMode[ k ] = CDTXMania.ConfigIni.eInvisible[ k ];
				if ( CDTXMania.DTXVmode.Enabled )
				{
					CDTXMania.ConfigIni.n譜面スクロール速度[ k ] = CDTXMania.ConfigIni.nViewerScrollSpeed[ k ];
				}

				this.nInputAdjustTimeMs[ k ] = CDTXMania.ConfigIni.nInputAdjustTimeMs[ k ];			// #23580 2011.1.3 yyagi
																									//        2011.1.7 ikanick 修正
				//this.nJudgeLinePosY_delta[ k ] = CDTXMania.ConfigIni.nJudgeLinePosOffset[ k ];		// #31602 2013.6.23 yyagi

				this.演奏判定ライン座標.n判定位置[ k ] = CDTXMania.ConfigIni.e判定位置[ k ];
				this.演奏判定ライン座標.nJudgeLinePosY_delta[ k ] = CDTXMania.ConfigIni.nJudgeLinePosOffset[ k ];
				this.bReverse[ k ]             = CDTXMania.ConfigIni.bReverse[ k ];					//

			}
			actCombo.演奏判定ライン座標 = 演奏判定ライン座標;
			for ( int i = 0; i < 3; i++ )
			{
				this.b演奏にキーボードを使った[ i ] = false;
				this.b演奏にジョイパッドを使った[ i ] = false;
				this.b演奏にMIDI入力を使った[ i ] = false;
				this.b演奏にマウスを使った[ i ] = false;
			}
			this.bAUTOでないチップが１つでもバーを通過した = false;
			cInvisibleChip.Reset();
			base.On活性化();
			this.tステータスパネルの選択();
			this.tパネル文字列の設定();
			//this.演奏判定ライン座標();
            this.bIsGOGOTIME = false;
            this.bUseBranch = false;
            this.n現在のコース = 0;
            this.n次回のコース = 0;
            this.b連打中 = false;
            this.n現在の連打数 = 0;
            this.n合計連打数 = 0;
            this.n分岐した回数 = 0;
            this.n表示した歌詞 = 0;
            this.nJPOSSCROLL = 0;
            this.bLEVELHOLD = false;

            this.bDoublePlay = CDTXMania.ConfigIni.bSession;

            this.nLoopCount_Clear = 1;

            #region[ branch ]
            this.nBranch_Perfect = 0;
            this.nBranch_Good = 0;
            this.nBranch_Miss = 0;
            this.nBranch_roll = 0;
            #endregion

            this.bIsAutoPlay = CDTXMania.ConfigIni.bAutoPlay;									// #24239 2011.1.23 yyagi

			
			//this.bIsAutoPlay.Guitar = CDTXMania.ConfigIni.bギターが全部オートプレイである;
			//this.bIsAutoPlay.Bass = CDTXMania.ConfigIni.bベースが全部オートプレイである;
//			this.nRisky = CDTXMania.ConfigIni.nRisky;											// #23559 2011.7.28 yyagi
			actGauge.Init( CDTXMania.ConfigIni.nRisky );									// #23559 2011.7.28 yyagi
			this.nPolyphonicSounds = CDTXMania.ConfigIni.nPoliphonicSounds;
			e判定表示優先度 = CDTXMania.ConfigIni.e判定表示優先度;

			CDTXMania.Skin.tRemoveMixerAll();	// 効果音のストリームをミキサーから解除しておく

			queueMixerSound = new Queue<stmixer>( 64 );
			bIsDirectSound = ( CDTXMania.Sound管理.GetCurrentSoundDeviceType() == "DirectSound" );
			bUseOSTimer = CDTXMania.ConfigIni.bUseOSTimer;
			this.bPAUSE = false;
			if ( CDTXMania.DTXVmode.Enabled )
			{
				db再生速度 = CDTXMania.DTX.dbDTXVPlaySpeed;
				CDTXMania.ConfigIni.n演奏速度 = (int) (CDTXMania.DTX.dbDTXVPlaySpeed * 20 + 0.5 );
			}
			else
			{
				db再生速度 = ( (double) CDTXMania.ConfigIni.n演奏速度 ) / 20.0;
			}
			bValidScore = ( CDTXMania.DTXVmode.Enabled ) ? false : true;

			#region [ 演奏開始前にmixer登録しておくべきサウンド(開幕してすぐに鳴らすことになるチップ音)を登録しておく ]
			foreach ( CDTX.CChip pChip in listChip )
			{
//				Debug.WriteLine( "CH=" + pChip.nチャンネル番号.ToString( "x2" ) + ", 整数値=" + pChip.n整数値 +  ", time=" + pChip.n発声時刻ms );
				if ( pChip.n発声時刻ms <= 0 )
				{
					if ( pChip.nチャンネル番号 == 0xDA )
					{
						pChip.bHit = true;
//						Trace.TraceInformation( "first [DA] BAR=" + pChip.n発声位置 / 384 + " ch=" + pChip.nチャンネル番号.ToString( "x2" ) + ", wav=" + pChip.n整数値 + ", time=" + pChip.n発声時刻ms );
						if ( listWAV.ContainsKey( pChip.n整数値_内部番号 ) )
						{
							CDTX.CWAV wc = listWAV[ pChip.n整数値_内部番号 ];
							for ( int i = 0; i < nPolyphonicSounds; i++ )
							{
								if ( wc.rSound[ i ] != null )
								{
									CDTXMania.Sound管理.AddMixer( wc.rSound[ i ], db再生速度, pChip.b演奏終了後も再生が続くチップである );
									//AddMixer( wc.rSound[ i ] );		// 最初はqueueを介さず直接ミキサー登録する
								}
							}
						}
					}
				}
				else
				{
					break;
				}
			}
			#endregion

			this.sw = new Stopwatch();
			this.sw2 = new Stopwatch();
//			this.gclatencymode = GCSettings.LatencyMode;
//			GCSettings.LatencyMode = GCLatencyMode.Batch;	// 演奏画面中はGCを抑止する
		}
		public override void On非活性化()
		{
			this.L最後に再生したHHの実WAV番号.Clear();	// #23921 2011.1.4 yyagi
			this.L最後に再生したHHの実WAV番号 = null;	//
			this.ctチップ模様アニメ.Drums = null;
			this.ctチップ模様アニメ.Guitar = null;
			this.ctチップ模様アニメ.Bass = null;
			this.ctチップ模様アニメ.Taiko = null;
			//listWAV.Clear();
			listWAV = null;
			listChip = null;
			queueMixerSound.Clear();
			queueMixerSound = null;
			cInvisibleChip.Dispose();
			cInvisibleChip = null;
//			GCSettings.LatencyMode = this.gclatencymode;

            base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if ( !base.b活性化してない )
			{
				this.t背景テクスチャの生成();
				base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if ( !base.b活性化してない )
			{
				CDTXMania.tテクスチャの解放( ref this.tx背景 );
				base.OnManagedリソースの解放();
			}
		}

		// その他

		#region [ protected ]
		//-----------------
		public class CHITCOUNTOFRANK
		{
			// Fields
			public int Good;
			public int Great;
			public int Miss;
			public int Perfect;
			public int Poor;

			// Properties
			public int this[ int index ]
			{
				get
				{
					switch ( index )
					{
						case 0:
							return this.Perfect;

						case 1:
							return this.Great;

						case 2:
							return this.Good;

						case 3:
							return this.Poor;

						case 4:
							return this.Miss;
					}
					throw new IndexOutOfRangeException();
				}
				set
				{
					switch ( index )
					{
						case 0:
							this.Perfect = value;
							return;

						case 1:
							this.Great = value;
							return;

						case 2:
							this.Good = value;
							return;

						case 3:
							this.Poor = value;
							return;

						case 4:
							this.Miss = value;
							return;
					}
					throw new IndexOutOfRangeException();
				}
			}
		}

		[StructLayout( LayoutKind.Sequential )]
		protected struct STKARAUCHI
		{
			public CDTX.CChip HH;
			public CDTX.CChip SD;
			public CDTX.CChip BD;
			public CDTX.CChip HT;
			public CDTX.CChip LT;
			public CDTX.CChip FT;
			public CDTX.CChip CY;
			public CDTX.CChip HHO;
			public CDTX.CChip RD;
			public CDTX.CChip LC;
            public CDTX.CChip LP;
            public CDTX.CChip LBD;
			public CDTX.CChip this[ int index ]
			{
				get
				{
					switch ( index )
					{
						case 0:
							return this.HH;

						case 1:
							return this.SD;

						case 2:
							return this.BD;

						case 3:
							return this.HT;

						case 4:
							return this.LT;

						case 5:
							return this.FT;

						case 6:
							return this.CY;

						case 7:
							return this.HHO;

						case 8:
							return this.RD;

						case 9:
							return this.LC;

                        case 10:
                            return this.LP;

                        case 11:
                            return this.LBD;
					}
					throw new IndexOutOfRangeException();
				}
				set
				{
					switch ( index )
					{
						case 0:
							this.HH = value;
							return;

						case 1:
							this.SD = value;
							return;

						case 2:
							this.BD = value;
							return;

						case 3:
							this.HT = value;
							return;

						case 4:
							this.LT = value;
							return;

						case 5:
							this.FT = value;
							return;

						case 6:
							this.CY = value;
							return;

						case 7:
							this.HHO = value;
							return;

						case 8:
							this.RD = value;
							return;

						case 9:
							this.LC = value;
							return;

                        case 10:
                            this.LP = value;
                            return;
					}
					throw new IndexOutOfRangeException();
				}
			}
		}

		protected struct stmixer
		{
			internal bool bIsAdd;
			internal CSound csound;
			internal bool b演奏終了後も再生が続くチップである;
		};

		public CAct演奏AVI actAVI;
        public CAct演奏Drums飛んでいく音符 actChipFireTaiko;
		protected CAct演奏チップファイアGB actChipFireGB;
		public CAct演奏Combo共通 actCombo;
		protected CAct演奏Danger共通 actDANGER;
		//protected CActFIFOBlack actFI;
        protected CActFIFOStart actFI;
		protected CActFIFOBlack actFO;
		protected CActFIFOResult actFOClear;
		public    CAct演奏ゲージ共通 actGauge;

        public CAct演奏DrumsDancer actDancer;
		protected CAct演奏判定文字列共通 actJudgeString;
		public CAct演奏DrumsレーンフラッシュD actLaneFlushD;
		protected CAct演奏レーンフラッシュGB共通 actLaneFlushGB;
		protected CAct演奏パネル文字列 actPanel;
		protected CAct演奏演奏情報 actPlayInfo;
		public CAct演奏スコア共通 actScore;
		public CAct演奏ステージ失敗 actStageFailed;
		protected CAct演奏ステータスパネル共通 actStatusPanels;
		protected CAct演奏スクロール速度 act譜面スクロール速度;
		public    C演奏判定ライン座標共通 演奏判定ライン座標;
        protected CAct演奏Drums連打 actRoll;
        protected CAct演奏Drums風船 actBalloon;
        public CAct演奏Drumsキャラクター actChara;
        protected CAct演奏Drums連打キャラ actRollChara;
        protected CAct演奏Drumsコンボ吹き出し actComboBalloon;
        protected CAct演奏Combo音声 actComboVoice;
        protected CAct演奏PauseMenu actPauseMenu;
		public bool bPAUSE;
		protected STDGBVALUE<bool> b演奏にMIDI入力を使った;
		protected STDGBVALUE<bool> b演奏にキーボードを使った;
		protected STDGBVALUE<bool> b演奏にジョイパッドを使った;
		protected STDGBVALUE<bool> b演奏にマウスを使った;
		protected STDGBVALUE<CCounter> ctチップ模様アニメ;

		protected E演奏画面の戻り値 eフェードアウト完了時の戻り値;
        protected readonly int[] nチャンネル0Atoパッド08 = new int[] { 1, 2, 3, 4, 5, 7, 6, 1, 8, 0, 9, 9 };
        protected readonly int[] nチャンネル0Atoレーン07 = new int[] { 1, 2, 3, 4, 5, 7, 6, 1, 9, 0, 8, 8 };
                                                                    //                         RD LC  LP  RD
		protected readonly int[] nパッド0Atoチャンネル0A = new int[] { 0x11, 0x12, 0x13, 0x14, 0x15, 0x17, 0x16, 0x18, 0x19, 0x1a, 0x1b, 0x1c };
        protected readonly int[] nパッド0Atoパッド08 = new int[] { 1, 2, 3, 4, 5, 6, 7, 1, 8, 0, 9, 9 };// パッド画像のヒット処理用
                                                              //   HH SD BD HT LT FT CY HHO RD LC LP LBD
        protected readonly int[] nパッド0Atoレーン07 = new int[] { 1, 2, 3, 4, 5, 6, 7, 1, 9, 0, 8, 8 };
		public STDGBVALUE<CHITCOUNTOFRANK> nヒット数_Auto含まない;
		protected STDGBVALUE<CHITCOUNTOFRANK> nヒット数_Auto含む;
		protected int n現在のトップChip = -1;
		protected int[] n最後に再生したBGMの実WAV番号 = new int[ 50 ];
		protected int n最後に再生したHHのチャンネル番号;
		protected List<int> L最後に再生したHHの実WAV番号;		// #23921 2011.1.4 yyagi: change "int" to "List<int>", for recording multiple wav No.
		protected STLANEVALUE<int> n最後に再生した実WAV番号;	// #26388 2011.11.8 yyagi: change "n最後に再生した実WAV番号.GUITAR" and "n最後に再生した実WAV番号.BASS"
																//							into "n最後に再生した実WAV番号";
//		protected int n最後に再生した実WAV番号.GUITAR;
//		protected int n最後に再生した実WAV番号.BASS;

		protected volatile Queue<stmixer> queueMixerSound;		// #24820 2013.1.21 yyagi まずは単純にAdd/Removeを1個のキューでまとめて管理するやり方で設計する
		protected DateTime dtLastQueueOperation;				//
		protected bool bIsDirectSound;							//
		protected double db再生速度;
		protected bool bValidScore;
//		protected bool bDTXVmode;
//		protected STDGBVALUE<int> nJudgeLinePosY_delta;			// #31602 2013.6.23 yyagi 表示遅延対策として、判定ラインの表示位置をずらす機能を追加する
		protected STDGBVALUE<bool> bReverse;

		protected STDGBVALUE<Queue<CDTX.CChip>> queWailing;
		protected STDGBVALUE<CDTX.CChip> r現在の歓声Chip;
		protected CTexture txチップ;
		protected CTexture txヒットバー;

		protected CTexture tx背景;

		protected STDGBVALUE<int> nInputAdjustTimeMs;		// #23580 2011.1.3 yyagi
		protected STAUTOPLAY bIsAutoPlay;		// #24239 2011.1.23 yyagi
//		protected int nRisky_InitialVar, nRiskyTime;		// #23559 2011.7.28 yyagi → CAct演奏ゲージ共通クラスに隠蔽
		protected int nPolyphonicSounds;
		protected List<CDTX.CChip> listChip;
		protected Dictionary<int, CDTX.CWAV> listWAV;
		protected CInvisibleChip cInvisibleChip;
		protected bool bUseOSTimer;
		protected E判定表示優先度 e判定表示優先度;

        public bool bIsGOGOTIME;
        public bool bUseBranch;
        public int n現在のコース; //0:普通譜面 1:玄人譜面 2:達人譜面
        public int n次回のコース;
        public bool b連打中 = false; //奥の手
        protected int n風船残り = 0;
        protected int n現在の連打数 = 0;
        protected bool b譜面分岐中 = false;
        protected int n分岐した回数 = 0;
        protected int nJPOSSCROLL = 0;

        private bool b強制的に分岐させた = false;
        private bool bLEVELHOLD = false;
        protected int nBranch_roll = 0;
        protected int nBranch_Perfect = 0;
        protected int nBranch_Good = 0;
        protected int nBranch_Miss = 0;
        protected int nListCount;

        private int n表示した歌詞 = 0;
        private int n合計連打数;

        private int n連打終了時間ms;

        private long n制御タイマ;
        protected int n現在の音符の顔番号;

        protected int nWaitButton;
        
        protected E連打State eRollState;
        protected CDTX.CChip chip現在処理中の連打チップ;

        protected float play_bpm_time;
        protected const int NOTE_GAP = 25;
        
        public int nLoopCount_Clear;

        //Type-Bの場合
        //0:1～9
        //1:10～19
        //2:20～29
        //3:
        //4:
        //5:
        //6:
        //7:
        //8:
        //9:
        //10:100以降
        //
        //Type-Cの場合
        //0:1～9
        //1:10～29
        //2:30～49
        //3:50～99
        //4:100以降
        //5～9:使用しない
        //
        //Type-Aの場合は使いません。
        protected int[] nScore = new int[11];

        protected int nHand = 0;

        protected CSound soundRed;
        protected CSound soundBlue;
        protected CSound soundAdlib;



        public bool bDoublePlay; // 2016.08.21 kairera0467 表示だけ。

		protected Stopwatch sw;		// 2011.6.13 最適化検討用のストップウォッチ
		protected Stopwatch sw2;
//		protected GCLatencyMode gclatencymode;

		public void AddMixer( CSound cs, bool _b演奏終了後も再生が続くチップである )
		{
			stmixer stm = new stmixer()
			{
				bIsAdd = true,
				csound = cs,
				b演奏終了後も再生が続くチップである = _b演奏終了後も再生が続くチップである
			};
			queueMixerSound.Enqueue( stm );
//		Debug.WriteLine( "★Queue: add " + Path.GetFileName( stm.csound.strファイル名 ));
		}
		public void RemoveMixer( CSound cs )
		{
			stmixer stm = new stmixer()
			{
				bIsAdd = false,
				csound = cs,
				b演奏終了後も再生が続くチップである = false
			};
			queueMixerSound.Enqueue( stm );
//		Debug.WriteLine( "★Queue: remove " + Path.GetFileName( stm.csound.strファイル名 ));
		}
		public void ManageMixerQueue()
		{
			// もしサウンドの登録/削除が必要なら、実行する
			if ( queueMixerSound.Count > 0 )
			{
				//Debug.WriteLine( "☆queueLength=" + queueMixerSound.Count );
				DateTime dtnow = DateTime.Now;
				TimeSpan ts = dtnow - dtLastQueueOperation;
				if ( ts.Milliseconds > 7 )
				{
					for ( int i = 0; i < 2 && queueMixerSound.Count > 0; i++ )
					{
						dtLastQueueOperation = dtnow;
						stmixer stm = queueMixerSound.Dequeue();
						if ( stm.bIsAdd )
						{
							CDTXMania.Sound管理.AddMixer( stm.csound, db再生速度, stm.b演奏終了後も再生が続くチップである );
						}
						else
						{
							CDTXMania.Sound管理.RemoveMixer( stm.csound );
						}
					}
				}
			}
		}

		protected E判定 e指定時刻からChipのJUDGEを返す( long nTime, CDTX.CChip pChip, int nInputAdjustTime )
		{
			if ( pChip != null )
			{
				pChip.nLag = (int) ( nTime + nInputAdjustTime - pChip.n発声時刻ms );		// #23580 2011.1.3 yyagi: add "nInputAdjustTime" to add input timing adjust feature
				int nDeltaTime = Math.Abs( pChip.nLag );
				//Debug.WriteLine("nAbsTime=" + (nTime - pChip.n発声時刻ms) + ", nDeltaTime=" + (nTime + nInputAdjustTime - pChip.n発声時刻ms));

                if( pChip.nチャンネル番号 == 0x15 || pChip.nチャンネル番号 == 0x16 )
                {
				    if ( CSound管理.rc演奏用タイマ.n現在時刻ms > pChip.n発声時刻ms && CSound管理.rc演奏用タイマ.n現在時刻ms < pChip.nノーツ終了時刻ms )
				    {
					    return E判定.Perfect;
				    }
                }
                else if( pChip.nチャンネル番号 == 0x17 )
                {
				    if ( CSound管理.rc演奏用タイマ.n現在時刻ms >= pChip.n発声時刻ms - 17 && CSound管理.rc演奏用タイマ.n現在時刻ms < pChip.nノーツ終了時刻ms )
				    {
					    return E判定.Perfect;
				    }
                }
				if ( nDeltaTime <= CDTXMania.nPerfect範囲ms )
				{
					return E判定.Perfect;
				}
				if ( nDeltaTime <= CDTXMania.nGood範囲ms )
				{
                    if( CDTXMania.ConfigIni.bJust )
                        return E判定.Poor;
					return E判定.Good;
				}
				if ( nDeltaTime <= CDTXMania.nPoor範囲ms )
				{
					return E判定.Poor;
				}
			}
			return E判定.Miss;
		}

		protected CDTX.CChip r空うちChip( E楽器パート part, Eパッド pad )
		{
			return null;
		}
		protected CDTX.CChip r指定時刻に一番近いChip_ヒット未済問わず不可視考慮( long nTime, int nChannel, int nInputAdjustTime )
		{
			sw2.Start();
//Trace.TraceInformation( "NTime={0}, nChannel={1:x2}", nTime, nChannel );
			nTime += nInputAdjustTime;						// #24239 2011.1.23 yyagi InputAdjust

			int nIndex_InitialPositionSearchingToPast;
			if ( this.n現在のトップChip == -1 )				// 演奏データとして1個もチップがない場合は
			{
				sw2.Stop();
				return null;
			}
			int count = listChip.Count;
			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )			// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = count - 1;
			}
			//int nIndex_NearestChip_Future;	// = nIndex_InitialPositionSearchingToFuture;
			//while ( nIndex_NearestChip_Future < count )		// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++)
			{
				CDTX.CChip chip = listChip[ nIndex_NearestChip_Future ];

				if ( ( ( 0x11 <= nChannel ) && ( nChannel <= 0x14 ) ) || nChannel == 0x1F )
				{
					if ( ( ( chip.nチャンネル番号 == nChannel ) || ( chip.nチャンネル番号 == ( nChannel ) ) ) )
					{
						if ( chip.n発声時刻ms > nTime )
						{
							break;
						}
                        if( chip.nコース != this.n次回のコース )
                        {
                            break;
                        }
						nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
					}
					continue;	// ほんの僅かながら高速化
				}

				// nIndex_NearestChip_Future++;
			}
			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
			//while ( nIndex_NearestChip_Past >= 0 )			// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				CDTX.CChip chip = listChip[ nIndex_NearestChip_Past ];

				if ( ( 0x11 <= nChannel ) && ( nChannel <= 0x14 ) )
				{
					if ( ( ( chip.nチャンネル番号 == nChannel ) )  )
					{
						break;
					}
				}
				// nIndex_NearestChip_Past--;
			}

			if ( nIndex_NearestChip_Future >= count )
			{
				if ( nIndex_NearestChip_Past < 0 )	// 検索対象が過去未来どちらにも見つからなかった場合
				{
					return null;
				}
				else 								// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
				{
					sw2.Stop();
					return listChip[ nIndex_NearestChip_Past ];
				}
			}
			else if ( nIndex_NearestChip_Past < 0 )	// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
				sw2.Stop();
				return listChip[ nIndex_NearestChip_Future ];
			}
													// 検索対象が過去未来の双方に見つかったなら、より近い方を採用する
			CDTX.CChip nearestChip_Future = listChip[ nIndex_NearestChip_Future ];
			CDTX.CChip nearestChip_Past   = listChip[ nIndex_NearestChip_Past ];
			int nDiffTime_Future = Math.Abs( (int) ( nTime - nearestChip_Future.n発声時刻ms ) );
			int nDiffTime_Past   = Math.Abs( (int) ( nTime - nearestChip_Past.n発声時刻ms ) );
			if ( nDiffTime_Future >= nDiffTime_Past )
			{
				sw2.Stop();
				return nearestChip_Past;
			}
			sw2.Stop();
			return nearestChip_Future;
		}
		protected CDTX.CChip r指定時刻に一番近い連打Chip_ヒット未済問わず不可視考慮( long nTime, int nChannel, int nInputAdjustTime )
		{
			sw2.Start();
//Trace.TraceInformation( "NTime={0}, nChannel={1:x2}", nTime, nChannel );
			nTime += nInputAdjustTime;						// #24239 2011.1.23 yyagi InputAdjust

			int nIndex_InitialPositionSearchingToPast;
			if ( this.n現在のトップChip == -1 )				// 演奏データとして1個もチップがない場合は
			{
				sw2.Stop();
				return null;
			}
			int count = listChip.Count;
			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )			// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = count - 1;
			}
			//int nIndex_NearestChip_Future;	// = nIndex_InitialPositionSearchingToFuture;
			//while ( nIndex_NearestChip_Future < count )		// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++)
			{
				CDTX.CChip chip = listChip[ nIndex_NearestChip_Future ];

				if ( ( ( 0x11 <= nChannel ) && ( nChannel <= 0x17 ) ) )
				{
					if ( ( ( chip.nチャンネル番号 == nChannel ) || ( chip.nチャンネル番号 == ( nChannel ) ) ) )
					{
						if ( chip.n発声時刻ms > nTime )
						{
							break;
						}
                        if( chip.nコース != this.n次回のコース )
                        {
                            break;
                        }
						nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
					}
					continue;	// ほんの僅かながら高速化
				}

				// nIndex_NearestChip_Future++;
			}
			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
			//while ( nIndex_NearestChip_Past >= 0 )			// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				CDTX.CChip chip = listChip[ nIndex_NearestChip_Past ];

				if ( ( 0x15 <= nChannel ) && ( nChannel <= 0x17 ) )
				{
					if ( ( ( chip.nチャンネル番号 == nChannel ) )  )
					{
						break;
					}
				}
				// nIndex_NearestChip_Past--;
			}

			if ( nIndex_NearestChip_Future >= count )
			{
				if ( nIndex_NearestChip_Past < 0 )	// 検索対象が過去未来どちらにも見つからなかった場合
				{
					return null;
				}
				else 								// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
				{
					sw2.Stop();
					return listChip[ nIndex_NearestChip_Past ];
				}
			}
			else if ( nIndex_NearestChip_Past < 0 )	// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
				sw2.Stop();
				return listChip[ nIndex_NearestChip_Future ];
			}
													// 検索対象が過去未来の双方に見つかったなら、より近い方を採用する
			CDTX.CChip nearestChip_Future = listChip[ nIndex_NearestChip_Future ];
			CDTX.CChip nearestChip_Past   = listChip[ nIndex_NearestChip_Past ];
			int nDiffTime_Future = Math.Abs( (int) ( nTime - nearestChip_Future.n発声時刻ms ) );
			int nDiffTime_Past   = Math.Abs( (int) ( nTime - nearestChip_Past.n発声時刻ms ) );
			if ( nDiffTime_Future >= nDiffTime_Past )
			{
				sw2.Stop();
				return nearestChip_Past;
			}
			sw2.Stop();
			return nearestChip_Future;
		}
		protected void tサウンド再生( CDTX.CChip rChip, long n再生開始システム時刻ms, E楽器パート part )
		{
			this.tサウンド再生( rChip, n再生開始システム時刻ms, part, CDTXMania.ConfigIni.n手動再生音量, false, false );
		}
		protected void tサウンド再生( CDTX.CChip rChip, long n再生開始システム時刻ms, E楽器パート part, int n音量 )
		{
			this.tサウンド再生( rChip, n再生開始システム時刻ms, part, n音量, false, false );
		}
		protected void tサウンド再生( CDTX.CChip rChip, long n再生開始システム時刻ms, E楽器パート part, int n音量, bool bモニタ )
		{
			this.tサウンド再生( rChip, n再生開始システム時刻ms, part, n音量, bモニタ, false );
		}
		protected void tサウンド再生( CDTX.CChip pChip, long n再生開始システム時刻ms, E楽器パート part, int n音量, bool bモニタ, bool b音程をずらして再生 )
		{
			// mute sound (auto)
			// 4A: HH
			// 4B: CY
			// 4C: RD
			// 4D: LC
			// 2A: Gt
			// AA: Bs
			//

			if ( pChip != null )
			{
				bool overwrite = false;
				switch ( part )
				{
					case E楽器パート.DRUMS:
					#region [ DRUMS ]
						return;
					#endregion
					case E楽器パート.GUITAR:
					#region [ GUITAR ]
						return;
					#endregion
					case E楽器パート.BASS:
					#region [ BASS ]
						return;
					#endregion
                    case E楽器パート.TAIKO:
						{
							int index = pChip.nチャンネル番号;
                            if( index == 0x11 || index == 0x13 )
                                this.soundRed.t再生を開始する();
                            else if( index == 0x12 || index == 0x14 )
                                this.soundBlue.t再生を開始する();
                            else if( index == 0x1F )
                                this.soundAdlib.t再生を開始する();

                            if( this.nHand == 0 )
                                this.nHand++;
                            else
                                this.nHand = 0;

							return;
						}

					default:
						break;
				}
			}
		}
		protected void tステータスパネルの選択()
		{
			if ( CDTXMania.bコンパクトモード )
			{
				this.actStatusPanels.tラベル名からステータスパネルを決定する( null );
			}
			else if ( CDTXMania.stage選曲.r確定された曲 != null )
			{
				this.actStatusPanels.tラベル名からステータスパネルを決定する( CDTXMania.stage選曲.r確定された曲.ar難易度ラベル[ CDTXMania.stage選曲.n確定された曲の難易度 ] );
			}
		}

        protected bool tRollProcess( CDTX.CChip pChip, double dbProcess_time, int num, int sort, int Input )
        {
            if( dbProcess_time >= pChip.n発声時刻ms && dbProcess_time < pChip.nノーツ終了時刻ms )
            {
                if( pChip.nRollCount == 0 )
                {
                    this.actRoll.b表示 = true;
                    this.n現在の連打数 = 0;
                    this.actRoll.t枠表示時間延長();
                }

                this.b連打中 = true;
                if( pChip.nチャンネル番号 == 0x15 )
                    this.eRollState = E連打State.roll;
                else
                    this.eRollState = E連打State.rollB;
                pChip.nRollCount++;
                this.n現在の連打数++;
                this.nBranch_roll++;
                this.n合計連打数++;
                this.actRollChara.Start(0);

                //2017.01.28 DD CDTXから直接呼び出す
                if( this.bIsGOGOTIME )
                {
                    if( CDTXMania.DTX.nScoreModeTmp == 0 || CDTXMania.DTX.nScoreModeTmp == 1 )
                    {
                        if( pChip.nチャンネル番号 == 0x15 )
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, (long)( 300 * 1.2f ) );
                        else
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, (long)( 360 * 1.2f ) );
                    }
                    else
                    {
                        if( pChip.nチャンネル番号 == 0x15 )
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, (long)( 100 * 1.2f ) );
                        else
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, (long)( 200 * 1.2f ) );
                    }
                }
                else
                {
                    if( CDTXMania.DTX.nScoreModeTmp == 0 || CDTXMania.DTX.nScoreModeTmp == 1 )
                    {
                        if( pChip.nチャンネル番号 == 0x15 )
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, 100L );
                        else
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, 200L );
                    }
                    else
                    {
                        if( pChip.nチャンネル番号 == 0x15 )
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, 100L );
                        else
                            this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, 200L );
                    }
                }


                //赤か青かの分岐
                if( sort == 0 )
                {
                    this.soundRed.t再生を開始する();
                    if( pChip.nチャンネル番号 == 0x15 )
                    {
                        //CDTXMania.Skin.soundRed.t再生する();
                        CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start(1);
                    }
                    else
                    {
                        //CDTXMania.Skin.soundRed.t再生する();
                        CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start(3);
                    }
                }
                else
                {
                    this.soundBlue.t再生を開始する();
                    if( pChip.nチャンネル番号 == 0x15 )
                    {
                        //CDTXMania.Skin.soundBlue.t再生する();
                        CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start(2);
                    }
                    else
                    {
                        //CDTXMania.Skin.soundBlue.t再生する();
                        CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start(4);
                    }
                }
            }
            else
            {
                this.b連打中 = false;
                return true;
            }

            return false;
        }

        protected bool tBalloonProcess( CDTX.CChip pChip, double dbProcess_time, int num )
        {
            //if( dbProcess_time >= pChip.n発声時刻ms && dbProcess_time < pChip.nノーツ終了時刻ms )
            if ((int)CSound管理.rc演奏用タイマ.n現在時刻ms >= pChip.n発声時刻ms && (int)CSound管理.rc演奏用タイマ.n現在時刻ms <= pChip.nノーツ終了時刻ms)
            {
                if( pChip.nRollCount == 0 )
                {
                    this.n風船残り = pChip.nBalloon;
                }

                this.b連打中 = true;
                this.eRollState = E連打State.balloon;
                pChip.nRollCount++;
                this.n風船残り--;

                //分岐のための処理。実装してない。

                //赤か青かの分岐
                if( pChip.nBalloon == pChip.nRollCount )
                {
                    //ﾊﾟｧｰﾝ
                    CDTXMania.Skin.soundBalloon.t再生する();
                    CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start( 3 ); //ここで飛ばす。飛ばされるのは大音符のみ。
                    CDTXMania.stage演奏ドラム画面.actChipFireTaiko.t虹();
                    CDTXMania.stage演奏ドラム画面.actChipFireD.Start( 0 );
                    this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, 5000L );
                    pChip.bHit = true;
                    chip現在処理中の連打チップ.bHit = true;
                    //this.b連打中 = false;
                    //this.actChara.b風船連打中 = false;
                    pChip.b可視 = false;
                    this.eRollState = E連打State.none;
                }
                else
                {
                    this.actScore.Add( E楽器パート.TAIKO, this.bIsAutoPlay, 300L );
                    //CDTXMania.Skin.soundRed.t再生する();
                    this.soundRed.t再生を開始する();
                }
            }
            else
            {
                if( chip現在処理中の連打チップ != null )
                    chip現在処理中の連打チップ.bHit = true;
                this.b連打中 = false;
                this.actChara.b風船連打中 = false;
                return false;
            }

            return true;
        }

		protected E判定 tチップのヒット処理( long nHitTime, CDTX.CChip pChip )
		{
			return tチップのヒット処理( nHitTime, pChip, true );
		}
		protected abstract E判定 tチップのヒット処理( long nHitTime, CDTX.CChip pChip, bool bCorrectLane );
		protected E判定 tチップのヒット処理( long nHitTime, CDTX.CChip pChip, E楽器パート screenmode )		// E楽器パート screenmode
		{
			return tチップのヒット処理( nHitTime, pChip, screenmode, true, 1 );
		}
		protected unsafe E判定 tチップのヒット処理( long nHitTime, CDTX.CChip pChip, E楽器パート screenmode, bool bCorrectLane, int nNowInput )
		{
            //unsafeコードにつき、デバッグ中の変更厳禁!

            //if( ( pChip.nコース != this.n現在のコース ) && !CDTXMania.DTX.bチップがある.Branch )
                //return E判定.Auto;

            if( !pChip.b可視 )
                return E判定.Auto;

            if( pChip.nチャンネル番号 != 0x15 && pChip.nチャンネル番号 != 0x16 && pChip.nチャンネル番号 != 0x17 && pChip.nチャンネル番号 != 0x18 )
            {
			    pChip.bHit = true;
            }

			if ( pChip.e楽器パート == E楽器パート.UNKNOWN )
			{
				this.bAUTOでないチップが１つでもバーを通過した = true;
			}
			else
			{
				//cInvisibleChip.StartSemiInvisible( pChip.e楽器パート );
			}
			bool bPChipIsAutoPlay = bCheckAutoPlay( pChip );

			pChip.bIsAutoPlayed = bPChipIsAutoPlay;			// 2011.6.10 yyagi
			E判定 eJudgeResult = E判定.Auto;
			switch ( pChip.e楽器パート )
			{
				case E楽器パート.DRUMS:
					{
                        //int nInputAdjustTime = bPChipIsAutoPlay ? 0 : this.nInputAdjustTimeMs.Drums;
                        //eJudgeResult = (bCorrectLane)? this.e指定時刻からChipのJUDGEを返す( nHitTime, pChip, nInputAdjustTime ) : E判定.Miss;
						//.actJudgeString.Start( this.nチャンネル0Atoレーン07[ pChip.nチャンネル番号 - 0x11 ], bPChipIsAutoPlay ? E判定.Auto : eJudgeResult, pChip.nLag );
					}
					break;

				case E楽器パート.GUITAR:
					{
                        //int nInputAdjustTime = bPChipIsAutoPlay ? 0 : this.nInputAdjustTimeMs.Guitar;
                        //eJudgeResult = (bCorrectLane)? this.e指定時刻からChipのJUDGEを返す( nHitTime, pChip, nInputAdjustTime ) : E判定.Miss;
						//this.actJudgeString.Start( 10, bPChipIsAutoPlay ? E判定.Auto : eJudgeResult, pChip.nLag );
						break;
					}

				case E楽器パート.BASS:
					{
                        //int nInputAdjustTime = bPChipIsAutoPlay ? 0 : this.nInputAdjustTimeMs.Bass;
                        //eJudgeResult = (bCorrectLane)? this.e指定時刻からChipのJUDGEを返す( nHitTime, pChip, nInputAdjustTime ) : E判定.Miss;
						//this.actJudgeString.Start( 11, bPChipIsAutoPlay ? E判定.Auto : eJudgeResult, pChip.nLag );
					}
					break;
				case E楽器パート.TAIKO:
					{
                        //連打が短すぎると発声されない
                        int nInputAdjustTime = bPChipIsAutoPlay ? 0 : this.nInputAdjustTimeMs.Taiko;
						eJudgeResult = (bCorrectLane)? this.e指定時刻からChipのJUDGEを返す( nHitTime, pChip, nInputAdjustTime ) : E判定.Miss;
                        if( pChip.nチャンネル番号 == 0x15 || pChip.nチャンネル番号 == 0x16 )
                        {
                            #region[ 連打 ]
                            //---------------------------
                            this.b連打中 = true;
                            if( CDTXMania.ConfigIni.b太鼓パートAutoPlay )
                            {
                                if( CDTXMania.ConfigIni.bAuto先生の連打 )
                                {
                                    if( CSound管理.rc演奏用タイマ.n現在時刻ms > ( pChip.n発声時刻ms + ( 1000.0 / 15.0 ) * pChip.nRollCount ) )
                                    {
                                        if( this.nHand == 0 )
                                            this.nHand++;
                                        else
                                            this.nHand = 0;
                                        
                                        CDTXMania.stage演奏ドラム画面.actLaneFlushD.Start(2, 0);
                                        CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start( pChip.nチャンネル番号 == 0x15 ? 1 : 3 );
                                        CDTXMania.stage演奏ドラム画面.actMtaiko.tMtaikoEvent( pChip.nチャンネル番号, this.nHand );
                                

                                        this.tRollProcess( pChip, CSound管理.rc演奏用タイマ.n現在時刻ms, 1, 0, 0 );
                                    }
                                }
                            }
                            else
                            {
                                this.eRollState = E連打State.roll;
                                this.tRollProcess( pChip, CSound管理.rc演奏用タイマ.n現在時刻ms, 1, nNowInput, 0 );
                            }

                            break;
                            //---------------------------
                            #endregion
                        }
                        else if( pChip.nチャンネル番号 == 0x17 )
                        {
                            this.b連打中 = true;
                            this.actChara.b風船連打中 = true;

                            //if( pChip.n発声時刻ms > CSound管理.rc演奏用タイマ.n現在時刻ms && pChip.nノーツ終了時刻ms < CSound管理.rc演奏用タイマ.n現在時刻ms )
                            //{
                            //    this.b連打中 = false;
                            //    this.n現在の連打数 = 0;
                            //    break;
                            //}


                            //CDTXMania.stage演奏ドラム画面.actChipFireD.Start( pChip.nチャンネル番号, eJudgeResult );

                            if( CDTXMania.ConfigIni.b太鼓パートAutoPlay )
                            {
                                if( pChip.nBalloon != 0 )
                                {
                                    if( CSound管理.rc演奏用タイマ.n現在時刻ms > ( pChip.n発声時刻ms + ( ( pChip.nノーツ終了時刻ms - pChip.n発声時刻ms ) / pChip.nBalloon ) * pChip.nRollCount ) )
                                    {
                                        if( this.nHand == 0 )
                                            this.nHand++;
                                        else
                                            this.nHand = 0;

                                        CDTXMania.stage演奏ドラム画面.actLaneFlushD.Start(2, 0);
                                        CDTXMania.stage演奏ドラム画面.actMtaiko.tMtaikoEvent( pChip.nチャンネル番号, this.nHand );
                                
                                        this.tBalloonProcess( pChip, CSound管理.rc演奏用タイマ.n現在時刻ms, 0 );
                                        //if( this.tBalloonProcess( pChip, CSound管理.rc演奏用タイマ.n現在時刻ms, 0 ) )
                                        //{
                                        //}
                                    }
                                }
                            }
                            else
                            {
                                this.tBalloonProcess( pChip, CSound管理.rc演奏用タイマ.n現在時刻ms, 0 );
                            }


                            break;
                        }
                        else if( pChip.nチャンネル番号 == 0x18 )
                        {
                            if( pChip.nノーツ終了時刻ms <= CSound管理.rc演奏用タイマ.n現在時刻ms )
                            {
                                this.b連打中 = false;
                                //this.actChara.b風船連打中 = false;
                                pChip.bHit = true;
                                break;
                            }
                        }
                        else if( pChip.nチャンネル番号 == 0x1F )
                        {
                            if( eJudgeResult != E判定.Auto && eJudgeResult != E判定.Miss )
                            {
	    					    this.actJudgeString.Start( 0, E判定.Bad, pChip.nLag, pChip );
                                CDTXMania.stage演奏ドラム画面.actLaneTaiko.Start( 0x93, eJudgeResult, true );
                                CDTXMania.stage演奏ドラム画面.actChipFireD.Start( 0x93, eJudgeResult );
                            }
                            break;
                        }
                        else
                        {
                            if( eJudgeResult != E判定.Miss )
                            {
                                pChip.bShow = false;
                            }
                        }

                        if( eJudgeResult != E判定.Auto && eJudgeResult != E判定.Miss )
                        {
						    this.actJudgeString.Start( 0, CDTXMania.ConfigIni.b太鼓パートAutoPlay ? E判定.Auto : eJudgeResult, pChip.nLag, pChip );
                            CDTXMania.stage演奏ドラム画面.actLaneTaiko.Start( pChip.nチャンネル番号, eJudgeResult, true );
                            CDTXMania.stage演奏ドラム画面.actChipFireD.Start( pChip.nチャンネル番号, eJudgeResult );

                            if( nNowInput == 2 || nNowInput == 3 )
                            {
                                if( pChip.nチャンネル番号 == 0x13 )
                                    CDTXMania.stage演奏ドラム画面.actChipFireD.Start( 0 );
                                else if( pChip.nチャンネル番号 == 0x14 )
                                   CDTXMania.stage演奏ドラム画面.actChipFireD.Start( 1 );
                            }
                        }
                        else if( eJudgeResult != E判定.Poor && eJudgeResult != E判定.Bad )
                        {
						    this.actJudgeString.Start( 0, CDTXMania.ConfigIni.b太鼓パートAutoPlay ? E判定.Auto : eJudgeResult, pChip.nLag, pChip );
                        }

					}
					break;
			}

            if( eJudgeResult != E判定.Poor && eJudgeResult != E判定.Miss )
            {
                if( actGauge.db現在のゲージ値.Taiko < 80.0 )
                {
                    CDTXMania.stage演奏ドラム画面.actBackground.tFadeIn();
                }
            }

			if ( ( pChip.e楽器パート != E楽器パート.UNKNOWN ) )
			{
                if( pChip.nチャンネル番号 != 0x15 && pChip.nチャンネル番号 != 0x16 && pChip.nチャンネル番号 != 0x17 && pChip.nチャンネル番号 != 0x18 && pChip.nチャンネル番号 != 0x1F )
                {
                    if( pChip.nコース == this.n現在のコース )
                    {
				        actGauge.Damage( screenmode, pChip.e楽器パート, eJudgeResult );
                    }
                }

			}
			if ( eJudgeResult == E判定.Poor || eJudgeResult == E判定.Miss || eJudgeResult == E判定.Bad )
			{
				cInvisibleChip.ShowChipTemporally( pChip.e楽器パート );
			}
			switch ( pChip.e楽器パート )
			{
				case E楽器パート.DRUMS:
				case E楽器パート.GUITAR:
				case E楽器パート.BASS:
					break;
                case E楽器パート.TAIKO:
                    if( !CDTXMania.ConfigIni.b太鼓パートAutoPlay )
                    {
                        if( pChip.nチャンネル番号 == 0x15 || pChip.nチャンネル番号 == 0x16 || pChip.nチャンネル番号 == 0x17 || pChip.nチャンネル番号 == 0x18 )
                            break;

					    switch ( eJudgeResult )
					    {
                            case E判定.Perfect:
                                {
                                    this.nBranch_Perfect++;
                                    this.nヒット数_Auto含まない.Drums.Perfect++;
                                    this.actCombo.n現在のコンボ数.Drums++;
                                    this.actCombo.ctコンボ加算.n現在の値 = 0;
                                }
                                break;
                            case E判定.Great:
                            case E判定.Good:
                                {
                                    this.nBranch_Good++;
                                    this.nヒット数_Auto含まない.Drums.Great++;
                                    this.actCombo.n現在のコンボ数.Drums++;
                                    //this.actCombo.ctコンボ加算 = new CCounter( 0, 8, 10, CDTXMania.Timer );
                                    //this.actCombo.ctコンボ加算.t進行();
                                    this.actCombo.ctコンボ加算.n現在の値 = 0;
                                }
                                break;
                            case E判定.Poor:
		    				case E判定.Miss:
			    			case E判定.Bad:
                                {
                                    if( pChip.nチャンネル番号 == 0x1F )
                                        break;
                                    this.nBranch_Miss++;
					    		    this.nヒット数_Auto含まない.Drums.Miss++;
                                    this.actCombo.n現在のコンボ数.Drums = 0;
                                    this.actComboVoice.tリセット();
                                }
			    				break;
				    		default:
					    		this.nヒット数_Auto含む.Drums[ (int) eJudgeResult ]++;
		    					break;
			    		}
                    }
					else if ( CDTXMania.ConfigIni.b太鼓パートAutoPlay )
					{
						switch ( eJudgeResult )
						{
                            case E判定.Perfect:
                            case E判定.Great:
                            case E判定.Good:
                                {
                                    if( pChip.nチャンネル番号 != 0x15 && pChip.nチャンネル番号 != 0x16 && pChip.nチャンネル番号 != 0x17 && pChip.nチャンネル番号 != 0x18 )
                                    {
                                        this.nBranch_Perfect++;
                                        this.nヒット数_Auto含む.Drums.Perfect++;
                                        this.actCombo.n現在のコンボ数.Drums++;
                                        //this.actCombo.ctコンボ加算.t進行();
                                        this.actCombo.ctコンボ加算.n現在の値 = 0;
                                    }
                                }
                                break;

							default:
                                {
                                    if( pChip.nチャンネル番号 != 0x15 && pChip.nチャンネル番号 != 0x16 && pChip.nチャンネル番号 != 0x17 && pChip.nチャンネル番号 != 0x18 && pChip.nチャンネル番号 != 0x1F )
                                    {
                                        this.nBranch_Miss++;
								        this.actCombo.n現在のコンボ数.Drums = 0;
                                        this.actComboVoice.tリセット();
                                    }
                                }
								break;
						}
					}
                    #region[ コンボ音声 ]
                    if( pChip.nチャンネル番号 < 0x15 )
                    {

                        if( this.actCombo.n現在のコンボ数.Drums % 100 == 0 && this.actCombo.n現在のコンボ数.Drums > 0 )
                        {
                            this.actComboBalloon.Start( this.actCombo.n現在のコンボ数.Drums );
                        }
                        this.actComboVoice.t再生( this.actCombo.n現在のコンボ数.Drums );

                        this.t紙吹雪_開始();
                    }
                    #endregion

					break;


				default:
					break;
			}
			if ( ( ( pChip.e楽器パート != E楽器パート.UNKNOWN ) ) && ( eJudgeResult != E判定.Miss ) && ( eJudgeResult != E判定.Bad ) && ( eJudgeResult != E判定.Poor ) && ( pChip.nチャンネル番号 <= 0x14 ) )
			{
				int nCombos = this.actCombo.n現在のコンボ数.Drums;
                long nInit = CDTXMania.DTX.nScoreInit[ 0, CDTXMania.stage選曲.n確定された曲の難易度 ];
                long nDiff = CDTXMania.DTX.nScoreDiff[ CDTXMania.stage選曲.n確定された曲の難易度 ];
                long nAddScore = 0;

                if( CDTXMania.DTX.nScoreModeTmp == 3 )  //2016.07.04 kairera0467 真打モード。
                {
                    nAddScore = CDTXMania.DTX.nScoreInit[ 1, CDTXMania.stage選曲.n確定された曲の難易度 ];
                    if( nAddScore == 0 )
                    {
                        //可の時に0除算をするとエラーが発生するため、それらしい数値を自動算出する。
                        //メモ
                        //風船1回
                        nAddScore = 100;
                        //( 100万 - ( ( 風船の打数 - 風船音符の数 * 300 ) + ( 風船音符の数 * 5000 ) ) ) / ノーツ数
                        //(最大コンボ数＋大音符数)×初項＋(風船の総打数－風船数)×300＋風船数×5000
                        //int nBallonCount = 0;
                        //int nBallonNoteCount = CDTXMania.DTX.n風船数[ 2 ] + CDTXMania.DTX.n風船数[ 3 ];
                        //int test = ( 1000000 - ( ( nBallonCount - nBallonNoteCount * 300 ) + ( nBallonNoteCount * 5000 ) ) ) / ( CDTXMania.DTX.nノーツ数[ 2 ] + CDTXMania.DTX.nノーツ数[ 3 ] );
                    }

                    if (eJudgeResult == E判定.Great || eJudgeResult == E判定.Good)
                    {
                        nAddScore = nAddScore / 2;
                    }
                    this.actScore.Add( E楽器パート.TAIKO, bIsAutoPlay, nAddScore );
                }
                else if( CDTXMania.DTX.nScoreModeTmp == 2 )
                {
                    if (nCombos < 10)
                    {
                        nAddScore = this.nScore[ 0 ];
                    }
                    else if( nCombos >= 10 && nCombos <= 29 )
                    {
                        nAddScore = this.nScore[ 1 ];
                    }
                    else if( nCombos >= 30 && nCombos <= 49 )
                    {
                        nAddScore = this.nScore[ 2 ];
                    }
                    else if( nCombos >= 50 && nCombos <= 99 )
                    {
                        nAddScore = this.nScore[ 3 ];
                    }
                    else if (nCombos >= 100)
                    {
                        nAddScore = this.nScore[ 4 ];
                    }

                    if (eJudgeResult == E判定.Great || eJudgeResult == E判定.Good)
                    {
                        nAddScore = nAddScore / 2;
                    }

                    if( this.bIsGOGOTIME )
                    {
                        nAddScore = (int)(nAddScore * 1.2f);
                    }

                    //100コンボ毎のボーナス
                    if( nCombos % 100 == 0 && nCombos > 99 )
                    {
                        this.actScore.BonusAdd();
                    }

                    nAddScore = (int)( nAddScore / 10 );
                    nAddScore = (int)( nAddScore * 10 );

                    //大音符のボーナス
                    if( pChip.nチャンネル番号 == 0x13 || pChip.nチャンネル番号 == 0x14 )
                    {
                        nAddScore = nAddScore * 2;
                    }

                    this.actScore.Add( E楽器パート.TAIKO, bIsAutoPlay, nAddScore );
                    //this.actScore.Add( E楽器パート.DRUMS, bIsAutoPlay, nAddScore );
                }
                else if( CDTXMania.DTX.nScoreModeTmp == 1 )
                {
                    if (nCombos < 10)
                    {
                        nAddScore = this.nScore[ 0 ];
                    }
                    else if( nCombos >= 10 && nCombos <= 19 )
                    {
                        nAddScore = this.nScore[ 1 ];
                    }
                    else if( nCombos >= 20 && nCombos <= 29 )
                    {
                        nAddScore = this.nScore[ 2 ];
                    }
                    else if( nCombos >= 30 && nCombos <= 39 )
                    {
                        nAddScore = this.nScore[ 3 ];
                    }
                    else if( nCombos >= 40 && nCombos <= 49 )
                    {
                        nAddScore = this.nScore[ 4 ];
                    }
                    else if( nCombos >= 50 && nCombos <= 59 )
                    {
                        nAddScore = this.nScore[ 5 ];
                    }
                    else if( nCombos >= 60 && nCombos <= 69 )
                    {
                        nAddScore = this.nScore[ 6 ];
                    }
                    else if( nCombos >= 70 && nCombos <= 79 )
                    {
                        nAddScore = this.nScore[ 7 ];
                    }
                    else if( nCombos >= 80 && nCombos <= 89 )
                    {
                        nAddScore = this.nScore[ 8 ];
                    }
                    else if( nCombos >= 90 && nCombos <= 99 )
                    {
                        nAddScore = this.nScore[ 9 ];
                    }
                    else if( nCombos >= 100 )
                    {
                        nAddScore = this.nScore[ 10 ];
                    }

                    if (eJudgeResult == E判定.Great || eJudgeResult == E判定.Good)
                    {
                        nAddScore = nAddScore / 2;
                    }


                    if( this.bIsGOGOTIME )
                        nAddScore = (int)(nAddScore * 1.2f);

                    nAddScore = (int)( nAddScore / 10.0 );
                    nAddScore = (int)( nAddScore * 10 );

                    //大音符のボーナス
                    if( pChip.nチャンネル番号 == 0x13 || pChip.nチャンネル番号 == 0x14 )
                    {
                        nAddScore = nAddScore * 2;
                    }

                    this.actScore.Add( E楽器パート.TAIKO, bIsAutoPlay, nAddScore );
                }
                else
                {
                    if( eJudgeResult == E判定.Perfect )
                    {
                        if( nCombos < 200 )
                        {
                            nAddScore = 1000;
                        }
                        else
                        {
                            nAddScore = 2000;
                        }
                    }
                    else if (eJudgeResult == E判定.Great || eJudgeResult == E判定.Good)
                    {
                        if( nCombos < 200 )
                        {
                            nAddScore = 500;
                        }
                        else
                        {
                            nAddScore = 1000;
                        }
                    }

                    if( this.bIsGOGOTIME )
                        nAddScore = (int)(nAddScore * 1.2f);

                    //大音符のボーナス
                    if (pChip.nチャンネル番号 == 0x13 || pChip.nチャンネル番号 == 0x25 )
                    {
                        nAddScore = nAddScore * 2;
                    }


                    this.actScore.Add( E楽器パート.TAIKO, bIsAutoPlay, nAddScore );
                    //this.actScore.Add( E楽器パート.DRUMS, bIsAutoPlay, nAddScore );              
                }

                //CDTXMania.act文字コンソール.tPrint( 50, 220, C文字コンソール.Eフォント種別.赤, nAddScore.ToString() );
			}
			return eJudgeResult;
		}

        protected void t分岐状況チェック( int n現在時刻 )
        {

            //if()
            {


                for (int i = this.n現在のトップChip; i < CDTXMania.DTX.listChip.Count; i++ )
                {
                    if( (CDTXMania.DTX.listChip[ i ].nチャンネル番号 <= 0x11 && CDTXMania.DTX.listChip[ i ].nチャンネル番号 >= 0x18 ) != false )
                    {
                        if (CDTXMania.DTX.listChip[i].nコース == this.n現在のコース)
                        {
                            CDTXMania.DTX.listChip[i].b可視 = true;
                        }
                        else
                        {
                            CDTXMania.DTX.listChip[i].b可視 = false;
                        }
                    }

                }
            }
        }


		protected abstract void tチップのヒット処理_BadならびにTight時のMiss( E楽器パート part );
		protected abstract void tチップのヒット処理_BadならびにTight時のMiss( E楽器パート part, int nLane );
		protected void tチップのヒット処理_BadならびにTight時のMiss( E楽器パート part, E楽器パート screenmode )
		{
			this.tチップのヒット処理_BadならびにTight時のMiss( part, 0, screenmode );
		}
		protected void tチップのヒット処理_BadならびにTight時のMiss( E楽器パート part, int nLane, E楽器パート screenmode )
		{
            //まだpChipでのチャンネル判別に対応していない。

			this.bAUTOでないチップが１つでもバーを通過した = true;
			cInvisibleChip.StartSemiInvisible( part );
			cInvisibleChip.ShowChipTemporally( part );
			//this.t判定にあわせてゲージを増減する( screenmode, part, E判定.Miss );
			actGauge.Damage( screenmode, part, E判定.Miss );
			switch ( part )
			{
				case E楽器パート.DRUMS:
					if ( ( nLane >= 0 ) && ( nLane <= 10 ) )
					{
						//this.actJudgeString.Start( nLane, bIsAutoPlay[ nLane ] ? E判定.Auto : E判定.Miss, 999 );
					}
					this.actCombo.n現在のコンボ数.Drums = 0;
					return;

				case E楽器パート.GUITAR:
					//this.actJudgeString.Start( 13, E判定.Bad, 999 );
					this.actCombo.n現在のコンボ数.Guitar = 0;
					return;

				case E楽器パート.BASS:
					//this.actJudgeString.Start( 14, E判定.Bad, 999 );
					this.actCombo.n現在のコンボ数.Bass = 0;
					break;

				case E楽器パート.TAIKO:
					//this.actJudgeString.Start( 0, E判定.Bad, 999 );
					this.actCombo.n現在のコンボ数.Taiko = 0;
					break;

				default:
					return;
			}
		}

		protected CDTX.CChip r指定時刻に一番近い未ヒットChipを過去方向優先で検索する( long nTime, int nInputAdjustTime )
		{
			sw2.Start();
			nTime += nInputAdjustTime;

			int nIndex_InitialPositionSearchingToPast;
			int nTimeDiff;
			int count = listChip.Count;
			if ( count <= 0 )			// 演奏データとして1個もチップがない場合は
			{
				sw2.Stop();
				return null;
			}

			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )		// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future  = nIndex_InitialPositionSearchingToPast = count - 1;
			}
			// int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToFuture;
//			while ( nIndex_NearestChip_Future < count )	// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++ )
			{
				CDTX.CChip chip = listChip[ nIndex_NearestChip_Future ];
				if ( !chip.bHit && chip.b可視 )
				{
					if ( ( ( 0x11 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x18 ) ) || chip.nチャンネル番号 == 0x1F )
					{
						if ( chip.n発声時刻ms > nTime )
						{
							break;
						}
                        nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
					}
				}
                if( chip.bHit && chip.b可視 ) // 2015.11.5 kairera0467 連打対策
                {
                    if( ( 0x15 <= chip.nチャンネル番号) && ( chip.nチャンネル番号 <= 0x17 ) )
                    {
                        if (chip.nノーツ終了時刻ms > nTime)
                        {
                            nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
                            break;
                        }
                    }
                }
//				nIndex_NearestChip_Future++;
			}
			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
//			while ( nIndex_NearestChip_Past >= 0 )		// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				CDTX.CChip chip = listChip[ nIndex_NearestChip_Past ];
				//if ( (!chip.bHit && chip.b可視 ) && ( (  0x93 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x99 ) ) )
                if ( (!chip.bHit && chip.b可視 ) && ( (  0x11 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x17 ) ) || chip.nチャンネル番号 == 0x1F )
					{
						break;
					}
                //2015.11.5 kairera0467 連打対策
				else if ( ( chip.b可視 ) && ( (  0x15 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x17 ) ) )
					{
						break;
					}
//				nIndex_NearestChip_Past--;
			}
			if ( ( nIndex_NearestChip_Future >= count ) && ( nIndex_NearestChip_Past < 0 ) )	// 検索対象が過去未来どちらにも見つからなかった場合
			{
				sw2.Stop();
				return null;
			}
			CDTX.CChip nearestChip;	// = null;	// 以下のifブロックのいずれかで必ずnearestChipには非nullが代入されるので、null初期化を削除
			if ( nIndex_NearestChip_Future >= count )											// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
			{
				nearestChip = listChip[ nIndex_NearestChip_Past ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else if ( nIndex_NearestChip_Past < 0 )												// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
				nearestChip = listChip[ nIndex_NearestChip_Future ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else
			{
				int nTimeDiff_Future = Math.Abs( (int) ( nTime - listChip[ nIndex_NearestChip_Future ].n発声時刻ms ) );
				int nTimeDiff_Past   = Math.Abs( (int) ( nTime - listChip[ nIndex_NearestChip_Past   ].n発声時刻ms ) );
				if ( nTimeDiff_Future < nTimeDiff_Past )
				{
                    if( !listChip[ nIndex_NearestChip_Past ].bHit && ( listChip[ nIndex_NearestChip_Past ].n発声時刻ms + ( 108 ) >= nTime ) )
                    {
					    nearestChip = listChip[ nIndex_NearestChip_Past ];
                    }
                    else
					    nearestChip = listChip[ nIndex_NearestChip_Future ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
				else
				{
					nearestChip = listChip[ nIndex_NearestChip_Past ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}

                //2015.11.5 kairera0467　連打音符の判定
                if( listChip[ nIndex_NearestChip_Future ].nチャンネル番号 >= 0x15 && listChip[ nIndex_NearestChip_Future ].nチャンネル番号 <= 0x17 )
                {
                    if( listChip[ nIndex_NearestChip_Future ].n発声時刻ms <= nTime && listChip[ nIndex_NearestChip_Future ].nノーツ終了時刻ms >= nTime )
                    {
                        nearestChip = listChip[ nIndex_NearestChip_Future ];
                    }
                }
			}
			nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
            int n検索範囲時間ms = 0;
			if ( ( n検索範囲時間ms > 0 ) && ( nTimeDiff > n検索範囲時間ms ) )					// チップは見つかったが、検索範囲時間外だった場合
			{
				sw2.Stop();
				return null;
			}
			sw2.Stop();
			return nearestChip;
		}

		protected CDTX.CChip r指定時刻に一番近い未ヒットChip( long nTime, int nInputAdjustTime )
		{
			sw2.Start();
//Trace.TraceInformation( "nTime={0}, nChannel={1:x2}, 現在のTop={2}", nTime, nChannel,CDTXMania.DTX.listChip[ this.n現在のトップChip ].n発声時刻ms );
			nTime += nInputAdjustTime;

			int nIndex_InitialPositionSearchingToPast;
			int nTimeDiff;
			if ( this.n現在のトップChip == -1 )			// 演奏データとして1個もチップがない場合は
			{
				sw2.Stop();
				return null;
			}
			int count = listChip.Count;
			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )		// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future  = nIndex_InitialPositionSearchingToPast = count - 1;
			}
			// int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToFuture;
//			while ( nIndex_NearestChip_Future < count )	// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++ )
			{
				CDTX.CChip chip = listChip[ nIndex_NearestChip_Future ];
				if ( !chip.bHit && chip.b可視 )
				{
					if ( ( ( 0x11 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x1F ) ) )
					{
						if ( chip.n発声時刻ms > nTime )
						{
							break;
						}
						nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
					}
				}
//				nIndex_NearestChip_Future++;
			}
			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
//			while ( nIndex_NearestChip_Past >= 0 )		// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				CDTX.CChip chip = listChip[ nIndex_NearestChip_Past ];
				if ( (!chip.bHit && chip.b可視 ) &&
						(
							(
								( ( (  0x11 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x1F ) ) )
							)
						)
					)
					{
						break;
					}
//				nIndex_NearestChip_Past--;
			}
			if ( ( nIndex_NearestChip_Future >= count ) && ( nIndex_NearestChip_Past < 0 ) )	// 検索対象が過去未来どちらにも見つからなかった場合
			{
				sw2.Stop();
				return null;
			}
			CDTX.CChip nearestChip;	// = null;	// 以下のifブロックのいずれかで必ずnearestChipには非nullが代入されるので、null初期化を削除
			if ( nIndex_NearestChip_Future >= count )											// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
			{
				nearestChip = listChip[ nIndex_NearestChip_Past ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else if ( nIndex_NearestChip_Past < 0 )												// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
				nearestChip = listChip[ nIndex_NearestChip_Future ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else
			{
				int nTimeDiff_Future = Math.Abs( (int) ( nTime - listChip[ nIndex_NearestChip_Future ].n発声時刻ms ) );
				int nTimeDiff_Past   = Math.Abs( (int) ( nTime - listChip[ nIndex_NearestChip_Past   ].n発声時刻ms ) );
				if ( nTimeDiff_Future < nTimeDiff_Past )
				{
					nearestChip = listChip[ nIndex_NearestChip_Future ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
				else
				{
					nearestChip = listChip[ nIndex_NearestChip_Past ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
			}
			nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
            int n検索範囲時間ms = 0;
			if ( ( n検索範囲時間ms > 0 ) && ( nTimeDiff > n検索範囲時間ms ) )					// チップは見つかったが、検索範囲時間外だった場合
			{
				sw2.Stop();
				return null;
			}
			sw2.Stop();
			return nearestChip;
		}
	
		protected CDTX.CChip r指定時刻に一番近い未ヒットChip( long nTime, int nChannelFlag, int nInputAdjustTime )
		{
			return this.r指定時刻に一番近い未ヒットChip( nTime, nChannelFlag, nInputAdjustTime, 0 );
		}
		protected CDTX.CChip r指定時刻に一番近い未ヒットChip( long nTime, int nChannel, int nInputAdjustTime, int n検索範囲時間ms )
		{
			sw2.Start();
//Trace.TraceInformation( "nTime={0}, nChannel={1:x2}, 現在のTop={2}", nTime, nChannel,CDTXMania.DTX.listChip[ this.n現在のトップChip ].n発声時刻ms );
			nTime += nInputAdjustTime;

			int nIndex_InitialPositionSearchingToPast;
			int nTimeDiff;
			if ( this.n現在のトップChip == -1 )			// 演奏データとして1個もチップがない場合は
			{
				sw2.Stop();
				return null;
			}
			int count = listChip.Count;
			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )		// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future  = nIndex_InitialPositionSearchingToPast = count - 1;
			}
			// int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToFuture;
//			while ( nIndex_NearestChip_Future < count )	// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++ )
			{
				CDTX.CChip chip = listChip[ nIndex_NearestChip_Future ];
				if ( !chip.bHit )
				{
                    if( ( 0x11 <= nChannel) && ( nChannel <= 0x1F ) )
                    {
                        if ((chip.nチャンネル番号 == nChannel) || (chip.nチャンネル番号 == (nChannel + 0x20)))
                        {
                            if (chip.n発声時刻ms > nTime)
                            {
                                break;
                            }
                            nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
                        }
                        continue;
                    }

					//if ( ( ( 0xDE <= nChannel ) && ( nChannel <= 0xDF ) ) )
                    if ( ( ( 0xDF == nChannel ) ) )
					{
                        if( chip.nチャンネル番号 == nChannel )
                        {
						    if ( chip.n発声時刻ms > nTime )
						    {
						    	break;
						    }
						    nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
                        }
					}

                    if ( ( ( 0x50 == nChannel ) ) )
					{
                        if( chip.nチャンネル番号 == nChannel )
                        {
						    if ( chip.n発声時刻ms > nTime )
						    {
						    	break;
						    }
						    nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
                        }
					}

				}
//				nIndex_NearestChip_Future++;
			}
			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
//			while ( nIndex_NearestChip_Past >= 0 )		// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				CDTX.CChip chip = listChip[ nIndex_NearestChip_Past ];
				if ( (!chip.bHit) &&
						(
							(
                                ( ( ( ( nChannel >= 0x11 ) && ( nChannel <= 0x14 ) ) || nChannel == 0x1F ) && ( chip.nチャンネル番号 == nChannel ) )
							)
							||
							(
							//	( ( ( nChannel >= 0xDE ) && ( nChannel <= 0xDF ) ) && ( chip.nチャンネル番号 == nChannel ) )
	                            ( ( ( nChannel == 0xDF ) ) && ( chip.nチャンネル番号 == nChannel ) )
							)
							||
							(
							//	( ( ( nChannel >= 0xDE ) && ( nChannel <= 0xDF ) ) && ( chip.nチャンネル番号 == nChannel ) )
	                            ( ( ( nChannel == 0x50 ) ) && ( chip.nチャンネル番号 == nChannel ) )
							)
						)
					)
					{
						break;
					}
//				nIndex_NearestChip_Past--;
			}
			if ( ( nIndex_NearestChip_Future >= count ) && ( nIndex_NearestChip_Past < 0 ) )	// 検索対象が過去未来どちらにも見つからなかった場合
			{
				sw2.Stop();
				return null;
			}
			CDTX.CChip nearestChip;	// = null;	// 以下のifブロックのいずれかで必ずnearestChipには非nullが代入されるので、null初期化を削除
			if ( nIndex_NearestChip_Future >= count )											// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
			{
				nearestChip = listChip[ nIndex_NearestChip_Past ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else if ( nIndex_NearestChip_Past < 0 )												// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
				nearestChip = listChip[ nIndex_NearestChip_Future ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else
			{
				int nTimeDiff_Future = Math.Abs( (int) ( nTime - listChip[ nIndex_NearestChip_Future ].n発声時刻ms ) );
				int nTimeDiff_Past   = Math.Abs( (int) ( nTime - listChip[ nIndex_NearestChip_Past   ].n発声時刻ms ) );

                if( nChannel == 0xDF ) //0xDFの場合は過去方向への検索をしない
                {
                    return listChip[ nIndex_NearestChip_Future ];
                }

				if ( nTimeDiff_Future < nTimeDiff_Past )
				{
					nearestChip = listChip[ nIndex_NearestChip_Future ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
				else
				{
					nearestChip = listChip[ nIndex_NearestChip_Past ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
			}
			nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			if ( ( n検索範囲時間ms > 0 ) && ( nTimeDiff > n検索範囲時間ms ) )					// チップは見つかったが、検索範囲時間外だった場合
			{
				sw2.Stop();
				return null;
			}
			sw2.Stop();
			return nearestChip;
		}
		public bool r検索範囲内にチップがあるか調べる( long nTime, int nInputAdjustTime, int n検索範囲時間ms )
		{
			nTime += nInputAdjustTime;

			for ( int i = 0; i < listChip.Count; i++ )
			{
				CDTX.CChip chip = listChip[ i ];
				if ( !chip.bHit )
				{
					if ( ( ( 0x11 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x14 ) ) )
					{
						if ( chip.n発声時刻ms < nTime + n検索範囲時間ms )
						{
                            if( chip.nコース == this.n現在のコース ) //2016.06.14 kairera0467 譜面分岐も考慮するようにしてみる。
						        return true;
						}
					}
				}
			}
			
			return false;
		}

		protected void ChangeInputAdjustTimeInPlaying( IInputDevice keyboard, int plusminus )		// #23580 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
		{
			int part, offset = plusminus;
			if ( keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftShift ) || keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightShift ) )	// Guitar InputAdjustTime
			{
				part = (int) E楽器パート.GUITAR;
			}
			else if ( keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftAlt ) || keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightAlt ) )	// Bass InputAdjustTime
			{
				part = (int) E楽器パート.BASS;
			}
			else	// Drums InputAdjustTime
			{
				part = (int) E楽器パート.DRUMS;
			}
			if ( !keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftControl ) && !keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightControl ) )
			{
				offset *= 10;
			}

			this.nInputAdjustTimeMs[ part ] += offset;
			if ( this.nInputAdjustTimeMs[ part ] > 99 )
			{
				this.nInputAdjustTimeMs[ part ] = 99;
			}
			else if ( this.nInputAdjustTimeMs[ part ] < -99 )
			{
				this.nInputAdjustTimeMs[ part ] = -99;
			}
			CDTXMania.ConfigIni.nInputAdjustTimeMs[ part ] = this.nInputAdjustTimeMs[ part ];
		}

		protected abstract void t入力処理_ドラム();
		protected abstract void ドラムスクロール速度アップ();
		protected abstract void ドラムスクロール速度ダウン();
		protected void tキー入力()
		{
			IInputDevice keyboard = CDTXMania.Input管理.Keyboard;
			if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F1 ) &&
				( keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightShift ) || keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftShift ) ) )
			{	// shift+f1 (pause)
                //this.bPAUSE = !this.bPAUSE;
                //if ( this.bPAUSE )
                //{
                //    CSound管理.rc演奏用タイマ.t一時停止();
                //    CDTXMania.Timer.t一時停止();
                //    CDTXMania.DTX.t全チップの再生一時停止();
                //}
                //else
                //{
                //    CSound管理.rc演奏用タイマ.t再開();
                //    CDTXMania.Timer.t再開();
                //    CDTXMania.DTX.t全チップの再生再開();
                //}
			}
			if ( ( !this.bPAUSE && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				this.t入力処理_ドラム();
				if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.UpArrow ) && ( keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightShift ) || keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftShift ) ) )
				{	// shift (+ctrl) + UpArrow (BGMAdjust)
					CDTXMania.DTX.t各自動再生音チップの再生時刻を変更する( ( keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftControl ) || keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightControl ) ) ? 1 : 10 );
					CDTXMania.DTX.tWave再生位置自動補正();
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.DownArrow ) && ( keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightShift ) || keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftShift ) ) )
				{	// shift + DownArrow (BGMAdjust)
					CDTXMania.DTX.t各自動再生音チップの再生時刻を変更する( ( keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.LeftControl ) || keyboard.bキーが押されている( (int) SlimDX.DirectInput.Key.RightControl ) ) ? -1 : -10 );
					CDTXMania.DTX.tWave再生位置自動補正();
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.UpArrow ) )
				{	// UpArrow(scrollspeed up)
					ドラムスクロール速度アップ();
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.DownArrow ) )
				{	// DownArrow (scrollspeed down)
					ドラムスクロール速度ダウン();
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.Delete ) )
				{	// del (debug info)
					CDTXMania.ConfigIni.b演奏情報を表示する = !CDTXMania.ConfigIni.b演奏情報を表示する;
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.LeftArrow ) )		// #24243 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
				{
					ChangeInputAdjustTimeInPlaying( keyboard, -1 );
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.RightArrow ) )		// #24243 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
				{
					ChangeInputAdjustTimeInPlaying( keyboard, +1 );
				}
				else if ( ( base.eフェーズID == CStage.Eフェーズ.共通_通常状態 ) && ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.Escape ) || CDTXMania.Pad.b押されたGB( Eパッド.FT ) ) && !this.actPauseMenu.bIsActivePopupMenu )
				{	// escape (exit)
                    this.t演奏中止();
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.D1 ) )
				{
                    if( this.n分岐した回数 < CDTXMania.DTX.listBRANCH.Count )
                        this.t分岐処理( 0, CDTXMania.DTX.listBRANCH[ this.n分岐した回数 ].n命令時のChipList番号 );
                    CDTXMania.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化( this.n現在のコース, 0 );
                    CDTXMania.stage演奏ドラム画面.actMtaiko.tBranchEvent( this.n現在のコース, 0 );
                    this.n現在のコース = 0;
                    this.n次回のコース = 0;
                    this.b強制的に分岐させた = true;
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.D2 ) )		// #24243 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
				{
                    if( this.n分岐した回数 < CDTXMania.DTX.listBRANCH.Count )
                        this.t分岐処理( 1, CDTXMania.DTX.listBRANCH[ this.n分岐した回数 ].n命令時のChipList番号 );
                    CDTXMania.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化( this.n現在のコース, 1 );
                    CDTXMania.stage演奏ドラム画面.actMtaiko.tBranchEvent( this.n現在のコース, 1 );
                    this.n現在のコース = 1;
                    this.n次回のコース = 1;
                    this.b強制的に分岐させた = true;
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.D3 ) )		// #24243 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
				{
                    if( this.n分岐した回数 < CDTXMania.DTX.listBRANCH.Count )
                        this.t分岐処理( 2, CDTXMania.DTX.listBRANCH[ this.n分岐した回数 ].n命令時のChipList番号 );
                    CDTXMania.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化( this.n現在のコース, 2 );
                    CDTXMania.stage演奏ドラム画面.actMtaiko.tBranchEvent( this.n現在のコース, 2 );
                    this.n現在のコース = 2;
                    this.n次回のコース = 2;
                    this.b強制的に分岐させた = true;
				}

				if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F4 ) )
				{
                    if( CDTXMania.ConfigIni.bJudgeCountDisplay == false )
                        CDTXMania.ConfigIni.bJudgeCountDisplay = true;
                    else
                        CDTXMania.ConfigIni.bJudgeCountDisplay = false;
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F5 ) )
				{
                    switch( CDTXMania.ConfigIni.eClipDispType  )
                    {
                        case EClipDispType.OFF:
                            CDTXMania.ConfigIni.eClipDispType = EClipDispType.背景のみ;
                            break;
                        case EClipDispType.背景のみ:
                            CDTXMania.ConfigIni.eClipDispType = EClipDispType.ウィンドウのみ;
                            break;
                        case EClipDispType.ウィンドウのみ:
                            CDTXMania.ConfigIni.eClipDispType = EClipDispType.両方;
                            break;
                        case EClipDispType.両方:
                            CDTXMania.ConfigIni.eClipDispType = EClipDispType.OFF;
                            break;
                    }
				}
                //if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.F6 ) )
                //{
                //    if( CDTXMania.ConfigIni.b太鼓パートAutoPlay == false )
                //        CDTXMania.ConfigIni.b太鼓パートAutoPlay = true;
                //    else
                //        CDTXMania.ConfigIni.b太鼓パートAutoPlay = false;
                //}
			}
            if( !this.actPauseMenu.bIsActivePopupMenu && this.bPAUSE && ( ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.UpArrow ) )
				{	// UpArrow(scrollspeed up)
					ドラムスクロール速度アップ();
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.DownArrow ) )
				{	// DownArrow (scrollspeed down)
					ドラムスクロール速度ダウン();
				}
				else if ( keyboard.bキーが押された( (int) SlimDX.DirectInput.Key.Delete ) )
				{	// del (debug info)
					CDTXMania.ConfigIni.b演奏情報を表示する = !CDTXMania.ConfigIni.b演奏情報を表示する;
				}
            }
		}

		protected void t入力メソッド記憶( E楽器パート part )
		{
			if ( CDTXMania.Pad.st検知したデバイス.Keyboard )
			{
				this.b演奏にキーボードを使った[ (int) part ] = true;
			}
			if ( CDTXMania.Pad.st検知したデバイス.Joypad )
			{
				this.b演奏にジョイパッドを使った[ (int) part ] = true;
			}
			if ( CDTXMania.Pad.st検知したデバイス.MIDIIN )
			{
				this.b演奏にMIDI入力を使った[ (int) part ] = true;
			}
			if ( CDTXMania.Pad.st検知したデバイス.Mouse )
			{
				this.b演奏にマウスを使った[ (int) part ] = true;
			}
		}


		protected abstract void t進行描画_AVI();
		protected void t進行描画_AVI(int x, int y)
		{
			if ( ( ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) ) && ( !CDTXMania.ConfigIni.bストイックモード && CDTXMania.ConfigIni.bAVI有効 ) )
			{
				this.actAVI.t進行描画( x, y );
			}
		}
		protected abstract void t進行描画_DANGER();
		protected void t進行描画_MIDIBGM()
		{
			if ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED )
			{
				CStage.Eフェーズ eフェーズid1 = base.eフェーズID;
			}
		}
		protected void t進行描画_STAGEFAILED()
		{
			if ( ( ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED ) || ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) ) && ( ( this.actStageFailed.On進行描画() != 0 ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) ) )
			{
				this.eフェードアウト完了時の戻り値 = E演奏画面の戻り値.ステージ失敗;
				base.eフェーズID = CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト;
				this.actFO.tフェードアウト開始();
			}
		}

		protected void t進行描画_チップファイアGB()
		{
			this.actChipFireGB.On進行描画();
		}
		protected abstract void t進行描画_パネル文字列();
		protected void t進行描画_パネル文字列( int x, int y )
		{
			if ( ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				this.actPanel.t進行描画( x, y );
			}
		}
		protected void tパネル文字列の設定()
		{
			this.actPanel.SetPanelString( string.IsNullOrEmpty( CDTXMania.DTX.PANEL ) ? CDTXMania.DTX.TITLE : CDTXMania.DTX.PANEL );
		}


		protected void t進行描画_ゲージ()
		{
			if ( ( ( ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) ) ) )
			{
				this.actGauge.On進行描画();
			}
		}
		protected void t進行描画_コンボ()
		{
			this.actCombo.On進行描画();
		}
		protected void t進行描画_スコア()
		{
			this.actScore.On進行描画();
		}
		protected void t進行描画_ステータスパネル()
		{
			this.actStatusPanels.On進行描画();
		}
		protected bool t進行描画_チップ( E楽器パート ePlayMode )
		{
			if ( ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED ) || ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				return true;
			}
			if ( ( this.n現在のトップChip == -1 ) || ( this.n現在のトップChip >= listChip.Count ) )
			{
				return true;
			}
			if ( this.n現在のトップChip == -1 )
			{
				return true;
			}
            if( this.r指定時刻に一番近い未ヒットChip( (long)CSound管理.rc演奏用タイマ.n現在時刻ms, 0x50, 0, 1000000 ) == null )
            {
                this.actChara.b演奏中 = false;
            }

			//double speed = 264.0;	// BPM150の時の1小節の長さ[dot]
			const double speed = 324.0;	// BPM150の時の1小節の長さ[dot]

			//double ScrollSpeedDrums = (( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.0 ) * speed ) * 0.5 * 37.5 / 60000.0;
            double ScrollSpeedDrums = ((  this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.0 ) * speed ) * 0.5 * 37.5 / 60000.0;
			double ScrollSpeedGuitar = ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Guitar + 1.0 ) * 0.5 * 0.5 * 37.5 * speed / 60000.0;
			double ScrollSpeedBass = ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Bass + 1.0 ) * 0.5 * 0.5 * 37.5 * speed / 60000.0;
            double ScrollSpeedTaiko = (( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.0 ) * speed ) * 0.5 * 37.5 / 60000.0;

			CDTX dTX = CDTXMania.DTX;
			CConfigIni configIni = CDTXMania.ConfigIni;
            if( this.n分岐した回数 == 0 )
            {
                this.bUseBranch = dTX.bHIDDENBRANCH ? false : dTX.bチップがある.Branch;
            }


            //CDTXMania.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.灰, this.nLoopCount_Clear.ToString()  );

            //for ( int nCurrentTopChip = this.n現在のトップChip; nCurrentTopChip < dTX.listChip.Count; nCurrentTopChip++ )
            for ( int nCurrentTopChip = dTX.listChip.Count - 1; nCurrentTopChip > 0; nCurrentTopChip-- )
			{
				CDTX.CChip pChip = dTX.listChip[ nCurrentTopChip ];
//Debug.WriteLine( "nCurrentTopChip=" + nCurrentTopChip + ", ch=" + pChip.nチャンネル番号.ToString("x2") + ", 発音位置=" + pChip.n発声位置 + ", 発声時刻ms=" + pChip.n発声時刻ms );
				pChip.nバーからの距離dot.Drums = (int) ( ( pChip.n発声時刻ms - CSound管理.rc演奏用タイマ.n現在時刻 ) * ScrollSpeedDrums );
				pChip.nバーからの距離dot.Guitar = (int) ( ( pChip.n発声時刻ms - CSound管理.rc演奏用タイマ.n現在時刻 ) * ScrollSpeedGuitar );
				pChip.nバーからの距離dot.Bass = (int) ( ( pChip.n発声時刻ms - CSound管理.rc演奏用タイマ.n現在時刻 ) * ScrollSpeedBass );
                pChip.nバーからの距離dot.Taiko = (int) ( ( ( pChip.n発声時刻ms - CSound管理.rc演奏用タイマ.n現在時刻 ) * pChip.dbBPM * pChip.dbSCROLL * ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.5 ) ) / 628.7 );
                pChip.nバーからのノーツ末端距離dot.Drums = 0;
                pChip.nバーからのノーツ末端距離dot.Guitar = 0;
                pChip.nバーからのノーツ末端距離dot.Bass = 0;
                if( pChip.nノーツ終了時刻ms != 0 )
                    pChip.nバーからのノーツ末端距離dot.Taiko = (int) ( ( ( pChip.nノーツ終了時刻ms - CSound管理.rc演奏用タイマ.n現在時刻 ) * pChip.dbBPM * pChip.dbSCROLL * ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.5 ) ) / 628.7 );

                this.play_bpm_time = this.GetNowPBMTime( dTX, 0 );
                if( CDTXMania.ConfigIni.eScrollMode == EScrollMode.BMSCROLL )
                {
                    pChip.nバーからの距離dot.Taiko = (int)( ( ( pChip.fBMSCROLLTime * NOTE_GAP ) - ( this.play_bpm_time * NOTE_GAP ) ) * ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.5 ) );
                    if( pChip.nノーツ終了時刻ms != 0 )
                        pChip.nバーからのノーツ末端距離dot.Taiko = (int)( ( ( pChip.fBMSCROLLTime_end * NOTE_GAP) - ( this.play_bpm_time * NOTE_GAP ) ) * pChip.dbSCROLL * ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.5 ) );
                }
                else if( CDTXMania.ConfigIni.eScrollMode == EScrollMode.HSSCROLL )
                {
                    pChip.nバーからの距離dot.Taiko = (int)( ( ( pChip.fBMSCROLLTime * NOTE_GAP ) - ( this.play_bpm_time * NOTE_GAP ) ) * pChip.dbSCROLL * ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.5 ) );
                    if( pChip.nノーツ終了時刻ms != 0 )
                        pChip.nバーからのノーツ末端距離dot.Taiko = (int)( ( ( pChip.fBMSCROLLTime_end * NOTE_GAP) - ( this.play_bpm_time * NOTE_GAP ) ) * pChip.dbSCROLL * ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.5 ) );
                }

                
//				if ( ( ( nCurrentTopChip == this.n現在のトップChip ) && ( pChip.nバーからの距離dot.Drums < -65 ) ) && pChip.bHit )
				// #28026 2012.4.5 yyagi; 信心ワールドエンドの曲終了後リザルトになかなか行かない問題の修正
				//if ( ( dTX.listChip[ nCurrentTopChip ].nバーからの距離dot.Drums < -65 ) && dTX.listChip[ nCurrentTopChip ].bHit )
				{
//					nCurrentTopChip = ++this.n現在のトップChip;
					//++this.n現在のトップChip;
					//continue;
				}


				bool bPChipIsAutoPlay = bCheckAutoPlay( pChip );

				int nInputAdjustTime = ( bPChipIsAutoPlay || (pChip.e楽器パート == E楽器パート.UNKNOWN) )? 0 : this.nInputAdjustTimeMs[ (int) pChip.e楽器パート ];

				int instIndex = (int) pChip.e楽器パート;

                if( pChip.nチャンネル番号 >= 0x11 && pChip.nチャンネル番号 <= 0x14 )//|| pChip.nチャンネル番号 == 0x9A )
                {
				    if ( ( !pChip.bHit ) && ( ( pChip.n発声時刻ms + 120 ) < CSound管理.rc演奏用タイマ.n現在時刻ms )
                        && ( this.e指定時刻からChipのJUDGEを返す( CSound管理.rc演奏用タイマ.n現在時刻, pChip, nInputAdjustTime ) == E判定.Miss ) )
                       //( ( pChip.nバーからの距離dot.Taiko < -40 ) && ( this.e指定時刻からChipのJUDGEを返す( CSound管理.rc演奏用タイマ.n現在時刻, pChip, nInputAdjustTime ) == E判定.Miss ) ) )
				    {
    				    this.tチップのヒット処理( CSound管理.rc演奏用タイマ.n現在時刻, pChip );
                        pChip.eNoteState = ENoteState.bad;
	    			}
                }

                if( pChip.nバーからの距離dot[ instIndex ] < -150 )
                {
                    if( !( pChip.nチャンネル番号 >= 0x11 && pChip.nチャンネル番号 <= 0x14 ) )
                    {
                        //2016.02.11 kairera0467
                        //太鼓の単音符の場合は座標による判定を行わない。
                        //(ここで判定をすると高スピードでスクロールしている時に見逃し不可判定が行われない。)
                        pChip.bHit = true;
                    }
                }

                if( chip現在処理中の連打チップ != null )
                {
                    if( chip現在処理中の連打チップ.nチャンネル番号 >= 0x13 && chip現在処理中の連打チップ.nチャンネル番号 <= 0x15 )//|| pChip.nチャンネル番号 == 0x9A )
                    {
				        if ( ( !chip現在処理中の連打チップ.bHit ) &&
                           ( ( chip現在処理中の連打チップ.nバーからの距離dot.Taiko < -500 ) && ( chip現在処理中の連打チップ.n発声時刻ms <= CSound管理.rc演奏用タイマ.n現在時刻ms && chip現在処理中の連打チップ.nノーツ終了時刻ms >= CSound管理.rc演奏用タイマ.n現在時刻ms ) ) )
                           //( ( chip現在処理中の連打チップ.nバーからのノーツ末端距離dot.Taiko < -500 ) && ( chip現在処理中の連打チップ.n発声時刻ms <= CSound管理.rc演奏用タイマ.n現在時刻ms && chip現在処理中の連打チップ.nノーツ終了時刻ms >= CSound管理.rc演奏用タイマ.n現在時刻ms ) ) )
                           //( ( pChip.n発声時刻ms <= CSound管理.rc演奏用タイマ.n現在時刻ms && pChip.nノーツ終了時刻ms >= CSound管理.rc演奏用タイマ.n現在時刻ms ) ) )
		    		    {
                            if( CDTXMania.ConfigIni.b太鼓パートAutoPlay )
    		    		        this.tチップのヒット処理( CSound管理.rc演奏用タイマ.n現在時刻, chip現在処理中の連打チップ );
	    		    	}
                    }
                }
                
				switch ( pChip.nチャンネル番号 )
				{
					#region [ 01: BGM ]
					case 0x01:	// BGM
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							if ( configIni.bBGM音を発声する )
							{
								dTX.tチップの再生( pChip, CSound管理.rc演奏用タイマ.n前回リセットした時のシステム時刻 + pChip.n発声時刻ms, (int) Eレーン.BGM, dTX.nモニタを考慮した音量( E楽器パート.UNKNOWN ) );
							}
						}
						break;
					#endregion
					#region [ 03: BPM変更 ]
					case 0x03:	// BPM変更
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							this.actPlayInfo.dbBPM = ( ( ( (double) configIni.n演奏速度 ) / 20.0 ) ) * dTX.BASEBPM; //2016.07.10 kairera0467 太鼓の仕様にあわせて修正。(そもそもの仕様が不明&コードミス疑惑)
						}
						break;
					#endregion
					#region [ 04, 07: EmptySlot ]
					case 0x04:
					case 0x07:
						break;
					#endregion
					#region [ 08: BPM変更(拡張) ]
					case 0x08:	// BPM変更(拡張)
                        //CDTXMania.act文字コンソール.tPrint( 414 + pChip.nバーからの距離dot.Drums + 4, 192, C文字コンソール.Eフォント種別.白, "BRANCH START" + "  " + pChip.n整数値.ToString() );
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
                            if( pChip.nコース == this.n現在のコース )
                            {
							    if ( dTX.listBPM.ContainsKey( pChip.n整数値_内部番号 ) )
							    {
								    //this.actPlayInfo.dbBPM = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );// + dTX.BASEBPM;
							    }
                                //double bpm = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );
                                //int nUnit = (int)((60.0 / ( bpm ) / this.actChara.nキャラクター通常モーション枚数 ) * 1000 );
                                //int nUnit_gogo = (int)((60.0 / ( bpm ) / this.actChara.nキャラクターゴーゴーモーション枚数 ) * 1000 );
                                //this.actChara.ct通常モーション = new CCounter( 0, this.actChara.nキャラクター通常モーション枚数 - 1, nUnit, CDTXMania.Timer );
                                //this.actChara.ctゴーゴーモーション = new CCounter(0, this.actChara.nキャラクターゴーゴーモーション枚数 - 1, nUnit_gogo * 2, CDTXMania.Timer);

                            }
						}
						break;
					#endregion

					#region [ 11-1f: 太鼓1P ]
					case 0x11:
					case 0x12:
					case 0x13:
					case 0x14:
                        {
                            this.t進行描画_チップ_Taiko( configIni, ref dTX, ref pChip );
                        }
                        break;

					case 0x15:
					case 0x16:
					case 0x17:
					case 0x18:
                        {
                            //2015.03.28 kairera0467
                            //描画順序を変えるため、メイン処理だけをこちらに残して描画処理は分離。

                            //this.t進行描画_チップ_Taiko連打(configIni, ref dTX, ref pChip);
                            int t = (int)CSound管理.rc演奏用タイマ.n現在時刻ms;
                            //2015.04.13 kairera0467 ここを外さないと恋文2000の連打に対応できず、ここをつけないと他のコースと重なっている連打をどうにもできない。
                            //常時実行メソッドに渡したら対応できた!?
                            //if ((!pChip.bHit && (pChip.nバーからの距離dot.Drums < 0)))
                            {
                                if( ( pChip.n発声時刻ms <= (int)CSound管理.rc演奏用タイマ.n現在時刻ms && pChip.nノーツ終了時刻ms >= (int)CSound管理.rc演奏用タイマ.n現在時刻ms) && pChip.nチャンネル番号 != 0x9A)
                                {
                                    //if( this.n現在のコース == pChip.nコース )
                                    if( pChip.b可視 == true )
                                        this.chip現在処理中の連打チップ = pChip;
                                }
                            }

                            if ((!pChip.bHit && (pChip.nバーからの距離dot.Drums < 0)) && pChip.nチャンネル番号 != 0x18)
                            {
                                this.n連打終了時間ms = pChip.nノーツ終了時刻ms;
                            }
                            else if ((!pChip.bHit && (pChip.nバーからの距離dot.Drums < 0)) && pChip.nチャンネル番号 == 0x18)
                            {
                                this.b連打中 = false;
                                this.actRoll.b表示 = false;
                                this.actChara.b風船連打中 = false;
                                pChip.bHit = true;
                                if( chip現在処理中の連打チップ != null )
                                    chip現在処理中の連打チップ.bHit = true;
                                this.eRollState = E連打State.none;
                            }
                        }

                        break;
					case 0x19:
					case 0x1a:
                    case 0x1b:
                    case 0x1c:
                    case 0x1d:
                    case 0x1e:
                        break;

					case 0x1f:
                        {
                            this.t進行描画_チップ_Taiko( configIni, ref dTX, ref pChip );
                        }
						break;
					#endregion
					#region [ 20-2F: EmptySlot ]
					case 0x20:
					case 0x21:
					case 0x22:
					case 0x23:
					case 0x24:
					case 0x25:
					case 0x26:
					case 0x27:
					case 0x28:
                    case 0x29:
                    case 0x2a:
                    case 0x2b:
                    case 0x2c:
                    case 0x2d:
                    case 0x2e:
                    case 0x2f:
						break;
					#endregion
					#region [ 31-3f: EmptySlot ]
					case 0x31:
					case 0x32:
					case 0x33:
					case 0x34:
					case 0x35:
					case 0x36:
					case 0x37:
					case 0x38:
					case 0x39:
					case 0x3a:
                    case 0x3b:
                    case 0x3c:
                    case 0x3d:
                    case 0x3e:
                    case 0x3f:
						break;
					#endregion

					#region [ 50: 小節線 ]
					case 0x50:	// 小節線
						{
                            if ( !pChip.bHit && ( pChip.nバーからの距離dot.Taiko < 0 ) )
						    {
                                this.actChara.b演奏中 = true;
                                if( this.actPlayInfo.n小節番号 == 0 )
                                {
                                    double dbUnit = ( ( ( 60.0 / ( CDTXMania.stage演奏ドラム画面.actPlayInfo.dbBPM ) ) ));
                                    double dbUnit_gogo = ( ( ( 60.0 / ( CDTXMania.stage演奏ドラム画面.actPlayInfo.dbBPM ) ) ) );
                                    double dbUnit_clear = ( ( ( 60.0f / ( CDTXMania.stage演奏ドラム画面.actPlayInfo.dbBPM ) ) ) );

                                    dbUnit = Math.Ceiling( dbUnit * 1000.0 );
                                    dbUnit = dbUnit / 1000.0;

                                    this.actChara.ct通常モーション = new CCounter( 0, this.actChara.arモーション番号.Length - 1, dbUnit / this.actChara.arモーション番号.Length, CSound管理.rc演奏用タイマ );
                                    this.actChara.ctゴーゴーモーション = new CCounter( 0, this.actChara.arゴーゴーモーション番号.Length - 1, ( dbUnit_gogo * 2.0 ) / this.actChara.arゴーゴーモーション番号.Length, CSound管理.rc演奏用タイマ );
                                    this.actChara.ctクリア通常モーション = new CCounter( 0, this.actChara.arクリアモーション番号.Length - 1, ( dbUnit_clear * 2.0 ) / this.actChara.arクリアモーション番号.Length, CSound管理.rc演奏用タイマ );

                                    this.actChara.ct通常モーション.db現在の値 = 0;
                                    this.actDancer.ct通常モーション = new CCounter( 0, this.actDancer.arモーション番号_通常.Length - 1, ( dbUnit * 4.0) / this.actDancer.arモーション番号_通常.Length, CSound管理.rc演奏用タイマ );
                                    //this.actDancer.ctモブ = new CCounter( 1.0, 16.0, (( dbUnit / 16.0 )), CSound管理.rc演奏用タイマ );
                                   
                                    if( this.actChara.nキャラクターMAX通常モーション枚数 != 0 )
                                    {
                                        double dbUnit_max = ( ( ( 60.0 / ( CDTXMania.stage演奏ドラム画面.actPlayInfo.dbBPM ) ) ) / this.actChara.ar黄色モーション番号.Length );
                                        this.actChara.ctMAX通常モーション = new CCounter( 0, this.actChara.ar黄色モーション番号.Length - 1, dbUnit_max * 2, CSound管理.rc演奏用タイマ );
                                    }
                                    if( this.actChara.nキャラクターMAXゴーゴーモーション枚数 != 0 )
                                    {
                                        double dbUnit_max_gogo = ( ( ( 60.0 / ( CDTXMania.stage演奏ドラム画面.actPlayInfo.dbBPM ) ) ) / this.actChara.ar黄色ゴーゴーモーション番号.Length );
                                        this.actChara.ctMAXゴーゴーモーション = new CCounter( 0, this.actChara.ar黄色ゴーゴーモーション番号.Length - 1, dbUnit_max_gogo * 2, CSound管理.rc演奏用タイマ );
                                    }
                                }
                                if( pChip.nコース == this.n現在のコース )
                                    this.actPlayInfo.n小節番号++;
                                pChip.bHit = true;
                            }
                            this.t進行描画_チップ_小節線( configIni, ref dTX, ref pChip );
							break;
						}
					#endregion
					#region [ 51: 拍線 ]
					case 0x51:	// 拍線
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
						}
                        //太鼓では拍線を使わない。
						//this.txチップ.t2D描画( CDTXMania.app.Device, 295, configIni.bReverse.Drums ? ( ( 0x38 + pChip.nバーからの距離dot.Drums ) - 1 ) : ( ( 567 - pChip.nバーからの距離dot.Drums ) - 1 ), new Rectangle( 0, 772, 559, 2 ) );

                        //this.t進行描画_チップ_小節線( configIni, ref dTX, ref pChip );
						break;
					#endregion
					#region [ 52-53: EmptySlot ]
					case 0x52:
						break;
					#endregion
					#region [ 54: 動画再生 ]
					case 0x54:	// 動画再生
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							if ( configIni.bAVI有効 )
							{
								switch ( pChip.eAVI種別 )
								{
									case EAVI種別.AVI:
										if ( pChip.rAVI != null )
										{
											this.actAVI.Start( pChip.nチャンネル番号, pChip.rAVI, pChip.rDShow, 278, 355, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, pChip.n発声時刻ms );
										}
										break;
									case EAVI種別.Unknown:
										if ( pChip.rAVI != null || pChip.rDShow != null )
										{
											this.actAVI.Start( pChip.nチャンネル番号, pChip.rAVI, pChip.rDShow, 278, 355, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, pChip.n発声時刻ms );
										}
										break;
								}
							}
						}
						break;
					#endregion
                    #region[ 55-60: EmptySlot ]
                    case 0x55:
                    case 0x56:
                    case 0x57:
                    case 0x58:
                    case 0x59:
                        break;
                    #endregion
                    #region [ 61-89: EmptySlot ]
                    case 0x60:
                    case 0x61:
					case 0x62:
					case 0x63:
					case 0x64:
					case 0x65:
					case 0x66:
					case 0x67:
					case 0x68:
					case 0x69:
					case 0x70:
					case 0x71:
					case 0x72:
					case 0x73:
					case 0x74:
					case 0x75:
					case 0x76:
					case 0x77:
					case 0x78:
					case 0x79:
					case 0x80:
					case 0x81:
					case 0x82:
					case 0x83:
                    case 0x84:
                    case 0x85:
                    case 0x86:
                    case 0x87:
                    case 0x88:
                    case 0x89:
                        break;
					#endregion

                    #region[ 90-9B: EmptySlot ]
                    case 0x90:
					case 0x91:
					case 0x92:
                    case 0x93:
                    case 0x94:
                    case 0x95:
                    case 0x96:
                    case 0x97:
                    case 0x98:
                    case 0x99:
                    case 0x9A:
                    case 0x9B:
						break;
					#endregion

                    #region[ 9C-9F: 太鼓 ]
                    //0x9C BPM変化(アニメーション用)
                    case 0x9C:
                        //CDTXMania.act文字コンソール.tPrint( 414 + pChip.nバーからの距離dot.Taiko + 8, 192, C文字コンソール.Eフォント種別.白, "BPMCHANGE" );
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
                            if( pChip.nコース == this.n現在のコース )
                            {
							    if ( dTX.listBPM.ContainsKey( pChip.n整数値_内部番号 ) )
							    {
								    this.actPlayInfo.dbBPM = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );// + dTX.BASEBPM;
							    }
                                double bpm = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );
                                double dbUnit = ( ( ( 60.0 / ( bpm ) ) ));

                                this.actChara.ct通常モーション = new CCounter( 0, this.actChara.arモーション番号.Length - 1, dbUnit / this.actChara.arモーション番号.Length, CSound管理.rc演奏用タイマ );
                                this.actChara.ctゴーゴーモーション = new CCounter( 0, this.actChara.arゴーゴーモーション番号.Length - 1, ( dbUnit * 2 ) / this.actChara.arゴーゴーモーション番号.Length, CSound管理.rc演奏用タイマ );


                                if( this.actChara.nキャラクタークリアモーション枚数 != 0 )
                                {
                                    double dbUnit_clear = ( ( ( 60.0 / ( bpm ) ) ));
                                    this.actChara.ctクリア通常モーション = new CCounter( 0, this.actChara.arクリアモーション番号.Length - 1, ( dbUnit_clear * 2.0 ) / this.actChara.arクリアモーション番号.Length, CSound管理.rc演奏用タイマ );
                                }
                                if( this.actChara.nキャラクターMAX通常モーション枚数 != 0 )
                                {
                                    double dbUnit_max = ( ( ( 60.0 / ( bpm ) ) ) / this.actChara.ar黄色モーション番号.Length );
                                    this.actChara.ctMAX通常モーション = new CCounter( 0, this.actChara.ar黄色モーション番号.Length - 1, dbUnit_max * 2, CSound管理.rc演奏用タイマ );
                                }
                                if( this.actChara.nキャラクターMAXゴーゴーモーション枚数 != 0 )
                                {
                                    double dbUnit_max_gogo = ( ( ( 60.0 / ( bpm ) ) ) / this.actChara.ar黄色ゴーゴーモーション番号.Length );
                                    this.actChara.ctMAXゴーゴーモーション = new CCounter( 0, this.actChara.ar黄色ゴーゴーモーション番号.Length - 1, dbUnit_max_gogo * 2, CSound管理.rc演奏用タイマ );
                                }
//#if C_82D982F182AF82CD82A282AF82A2
                                for( int dancer = 0; dancer < 5; dancer++ )
                                    this.actDancer.st投げ上げ[ dancer ].ct進行 = new CCounter( 0, this.actDancer.arモーション番号_登場.Length - 1, dbUnit / this.actDancer.arモーション番号_登場.Length, CSound管理.rc演奏用タイマ );

                                this.actDancer.ct通常モーション = new CCounter( 0, this.actDancer.arモーション番号_通常.Length - 1, ( dbUnit * 4 ) / this.actDancer.arモーション番号_通常.Length, CSound管理.rc演奏用タイマ );
                                this.actDancer.ctモブ = new CCounter( 1.0, 16.0, (int)((60.0 / bpm / 16.0 ) * 1000 ), CSound管理.rc演奏用タイマ );
//#endif
                            }

						}
                        break;

                    case 0x9D: //SCROLL
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							if ( dTX.listSCROLL.ContainsKey( pChip.n整数値_内部番号 ) )
							{
								//this.actPlayInfo.dbBPM = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );// + dTX.BASEBPM;
							}
						}
                        break;

                    case 0x9E: //ゴーゴータイム
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            pChip.bHit = true;
                            this.bIsGOGOTIME = true;
                            CDTXMania.stage演奏ドラム画面.actLaneTaiko.GOGOSTART();
                        }
                        break;
                    case 0x9F: //ゴーゴータイム
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            pChip.bHit = true;
                            this.bIsGOGOTIME = false;
                        }
                        break;
                    #endregion

					#region [ a0-a8: EmptySlot ]
					case 0xa0:
					case 0xa1:
					case 0xa2:
					case 0xa3:
					case 0xa4:
					case 0xa5:
					case 0xa6:
					case 0xa7:
					case 0xa8:
                        break;
					#endregion
					#region [ B1～BC EmptySlot ]
					case 0xb1:
					case 0xb2:
					case 0xb3:
					case 0xb4:
					case 0xb5:
					case 0xb6:
					case 0xb7:
					case 0xb8:
					case 0xb9:
                    case 0xba:
                    case 0xbb:
					case 0xbc:
						break;
					#endregion
					#region [ c4, c7, d5-d9: EmptySlot ]
					case 0xc4:
					case 0xc7:
					case 0xd5:
					case 0xd6:	// BGA画像入れ替え
					case 0xd7:
					case 0xd8:
					case 0xd9:
                    //case 0xe0:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
						}
						break;
					#endregion

					#region [ da: ミキサーへチップ音追加 ]
					case 0xDA:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
//Debug.WriteLine( "[DA(AddMixer)] BAR=" + pChip.n発声位置 / 384 + " ch=" + pChip.nチャンネル番号.ToString( "x2" ) + ", wav=" + pChip.n整数値.ToString( "x2" ) + ", time=" + pChip.n発声時刻ms );
							pChip.bHit = true;
							if ( listWAV.ContainsKey( pChip.n整数値_内部番号 ) )	// 参照が遠いので後日最適化する
							{
								CDTX.CWAV wc = listWAV[ pChip.n整数値_内部番号 ];
								for ( int i = 0; i < nPolyphonicSounds; i++ )
								{
									if ( wc.rSound[ i ] != null )
									{
										//CDTXMania.Sound管理.AddMixer( wc.rSound[ i ] );
										AddMixer( wc.rSound[ i ], pChip.b演奏終了後も再生が続くチップである );
									}
								}
							}
						}
						break;
					#endregion
					#region [ db: ミキサーからチップ音削除 ]
					case 0xDB:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
//Debug.WriteLine( "[DB(RemoveMixer)] BAR=" + pChip.n発声位置 / 384 + " ch=" + pChip.nチャンネル番号.ToString( "x2" ) + ", wav=" + pChip.n整数値.ToString( "x2" ) + ", time=" + pChip.n発声時刻ms );
							pChip.bHit = true;
							if ( listWAV.ContainsKey( pChip.n整数値_内部番号 ) )	// 参照が遠いので後日最適化する
							{
							    CDTX.CWAV wc = listWAV[ pChip.n整数値_内部番号 ];
							    for ( int i = 0; i < nPolyphonicSounds; i++ )
							    {
									if ( wc.rSound[ i ] != null )
									{
										//CDTXMania.Sound管理.RemoveMixer( wc.rSound[ i ] );
										if ( !wc.rSound[ i ].b演奏終了後も再生が続くチップである )	// #32248 2013.10.16 yyagi
										{															// DTX終了後も再生が続くチップの0xDB登録をなくすことはできず。
											RemoveMixer( wc.rSound[ i ] );							// (ミキサー解除のタイミングが遅延する場合の対応が面倒なので。)
										}															// そこで、代わりにフラグをチェックしてミキサー削除ロジックへの遷移をカットする。
									}
							    }
							}
						}
						break;
                    #endregion

                    #region[ dc-df:太鼓(特殊命令) ]
                    case 0xDC: //DELAY
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							if ( dTX.listDELAY.ContainsKey( pChip.n整数値_内部番号 ) )
							{
								//this.actPlayInfo.dbBPM = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );// + dTX.BASEBPM;
							}
						}
                        break;
                    case 0xDD: //譜面分岐条件リセット
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            this.tBranchReset();
                            pChip.bHit = true;
                        }
                        break;
                    case 0xDE: //譜面分岐スタート
                        //可視化
                        //CDTXMania.act文字コンソール.tPrint( 414 + pChip.nバーからの距離dot.Taiko + 4, 192, C文字コンソール.Eフォント種別.白, "BRANCH START" + "  " + pChip.n整数値.ToString() );
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            CDTXMania.stage演奏ドラム画面.bUseBranch = true;
                            if( !this.bLEVELHOLD )
                            {
                                this.tBranchJudge(this.nBranch_roll, this.nBranch_Perfect, this.nBranch_Good, this.nBranch_Miss);
                                this.t分岐処理( this.n次回のコース, CDTXMania.DTX.listBRANCH[ this.n分岐した回数 ].n命令時のChipList番号 );
                                CDTXMania.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化( this.n現在のコース, this.n次回のコース );
                                CDTXMania.stage演奏ドラム画面.actMtaiko.tBranchEvent( this.n現在のコース, this.n次回のコース );
                                if( CDTXMania.DTX.listBRANCH[ this.n分岐した回数 ].n分岐の種類 == 0 )
                                {
                                    this.n現在のコース = this.n次回のコース;
                                }
                            }
                            //if( n現在のコース == pChip.nコース )
                                this.n分岐した回数++;

                            if( CDTXMania.ConfigIni.bAutoSection )
                            {
                                this.tBranchReset();
                            }


                            pChip.bHit = true;
                        }
                        break;
                    
                    case 0xDF:
                        //CDTXMania.act文字コンソール.tPrint( 414 + pChip.nバーからの距離dot.Taiko + 4, 192 + 16, C文字コンソール.Eフォント種別.白, "0XDF");
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            //精度分岐だとなんでか知らんが0xDE→0xDFにならない...
                            this.n現在のコース = this.n次回のコース;
                            this.b強制的に分岐させた = false;
                            this.chip現在処理中の連打チップ = null;

                            pChip.bHit = true;
                        }
                        break;
                    case 0xE0:
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            //#BARLINEONと#BARLINEOFF
                            //演奏中は使用しません。
                        }
                        break;
                    case 0xE1:
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            if( this.n現在のコース == pChip.nコース )
                            {
                                //LEVELHOLD
                                this.bLEVELHOLD = true;
                            }
                        }
                        break;
                    case 0xE2:
                        if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
                        {
                            CDTXMania.stage演奏ドラム画面.actLaneTaiko.t判定枠移動( dTX.listJPOSSCROLL[ nJPOSSCROLL ].db移動時間, dTX.listJPOSSCROLL[ nJPOSSCROLL ].n移動距離px, dTX.listJPOSSCROLL[ nJPOSSCROLL ].n移動方向 );
                            this.nJPOSSCROLL++;
                            pChip.bHit = true;
                        }
                        break;
                    #endregion
                    #region[ f1: 歌詞 ]
                    case 0xF1:
                        if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
                            if( dTX.listLiryc.Count > this.n表示した歌詞 )
                            {
                                this.actPanel.t歌詞テクスチャを生成する( dTX.listLiryc[ this.n表示した歌詞 ] );
                                this.n表示した歌詞++;
                            }
                            pChip.bHit = true;
                        }
                        break;
					#endregion
                    #region[ ff: 譜面の強制終了 ]
                    //バグで譜面がとてつもないことになっているため、#ENDがきたらこれを差し込む。
                    case 0xFF:
                        if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
                            return true;
                        }
                        break;
					#endregion

					#region [ その他(未定義) ]
					default:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
						}
						break;
					#endregion 
                }

            }
			return false;
		}

        protected bool t進行描画_チップ_連打( E楽器パート ePlayMode )
		{
			if ( ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED ) || ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				return true;
			}
			if ( ( this.n現在のトップChip == -1 ) || ( this.n現在のトップChip >= listChip.Count ) )
			{
				return true;
			}
			if ( this.n現在のトップChip == -1 )
			{
				return true;
			}

			//double speed = 264.0;	// BPM150の時の1小節の長さ[dot]
			const double speed = 324.0;	// BPM150の時の1小節の長さ[dot]

			//double ScrollSpeedDrums = (( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.0 ) * speed ) * 0.5 * 37.5 / 60000.0;
            double ScrollSpeedDrums = ((  this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.0 ) * speed ) * 0.5 * 37.5 / 60000.0;
			double ScrollSpeedGuitar = ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Guitar + 1.0 ) * 0.5 * 0.5 * 37.5 * speed / 60000.0;
			double ScrollSpeedBass = ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Bass + 1.0 ) * 0.5 * 0.5 * 37.5 * speed / 60000.0;
            double ScrollSpeedTaiko = (( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.0 ) * speed ) * 0.5 * 37.5 / 60000.0;

			CDTX dTX = CDTXMania.DTX;
			CConfigIni configIni = CDTXMania.ConfigIni;

            //for ( int nCurrentTopChip = this.n現在のトップChip; nCurrentTopChip < dTX.listChip.Count; nCurrentTopChip++ )
            for ( int nCurrentTopChip = dTX.listChip.Count - 1; nCurrentTopChip > 0; nCurrentTopChip-- )
			{
				CDTX.CChip pChip = dTX.listChip[ nCurrentTopChip ];

//Debug.WriteLine( "nCurrentTopChip=" + nCurrentTopChip + ", ch=" + pChip.nチャンネル番号.ToString("x2") + ", 発音位置=" + pChip.n発声位置 + ", 発声時刻ms=" + pChip.n発声時刻ms );
				pChip.nバーからの距離dot.Drums = (int) ( ( pChip.n発声時刻ms - CSound管理.rc演奏用タイマ.n現在時刻 ) * ScrollSpeedDrums );
				pChip.nバーからの距離dot.Guitar = (int) ( ( pChip.n発声時刻ms - CSound管理.rc演奏用タイマ.n現在時刻 ) * ScrollSpeedGuitar );
				pChip.nバーからの距離dot.Bass = (int) ( ( pChip.n発声時刻ms - CSound管理.rc演奏用タイマ.n現在時刻 ) * ScrollSpeedBass );
                pChip.nバーからの距離dot.Taiko = (int) ( ( ( pChip.n発声時刻ms - CSound管理.rc演奏用タイマ.n現在時刻 ) * pChip.dbBPM * pChip.dbSCROLL * ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.5 ) ) / 628.7 );
                pChip.nバーからのノーツ末端距離dot.Drums = 0;
                pChip.nバーからのノーツ末端距離dot.Guitar = 0;
                pChip.nバーからのノーツ末端距離dot.Bass = 0;
                if( pChip.nノーツ終了時刻ms != 0 )
                    pChip.nバーからのノーツ末端距離dot.Taiko = (int) ( ( ( pChip.nノーツ終了時刻ms - CSound管理.rc演奏用タイマ.n現在時刻 ) * pChip.dbBPM * pChip.dbSCROLL * ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.5 ) ) / 628.7 );

                this.play_bpm_time = this.GetNowPBMTime( dTX, 0 );
                if( CDTXMania.ConfigIni.eScrollMode == EScrollMode.BMSCROLL ) //BMSCROLL test
                {
                    pChip.nバーからの距離dot.Taiko = (int)( ( ( pChip.fBMSCROLLTime * NOTE_GAP ) - ( this.play_bpm_time * NOTE_GAP ) ) * ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.5 ) );
                    if( pChip.nノーツ終了時刻ms != 0 )
                        pChip.nバーからのノーツ末端距離dot.Taiko = (int)( ( ( pChip.fBMSCROLLTime_end * NOTE_GAP ) - ( this.play_bpm_time * NOTE_GAP ) ) * pChip.dbSCROLL * ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.5 ) );
                }
                else if( CDTXMania.ConfigIni.eScrollMode == EScrollMode.HSSCROLL )
                {
                    pChip.nバーからの距離dot.Taiko = (int)( ( ( pChip.fBMSCROLLTime * NOTE_GAP ) - ( this.play_bpm_time * NOTE_GAP ) ) * pChip.dbSCROLL * ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.5 ) );
                    if( pChip.nノーツ終了時刻ms != 0 )
                        pChip.nバーからのノーツ末端距離dot.Taiko = (int)( ( ( pChip.fBMSCROLLTime_end * NOTE_GAP ) - ( this.play_bpm_time * NOTE_GAP ) ) * pChip.dbSCROLL * ( this.act譜面スクロール速度.db現在の譜面スクロール速度.Drums + 1.5 ) );
                }

				bool bPChipIsAutoPlay = bCheckAutoPlay( pChip );

				int nInputAdjustTime = ( bPChipIsAutoPlay || (pChip.e楽器パート == E楽器パート.UNKNOWN) )? 0 : this.nInputAdjustTimeMs[ (int) pChip.e楽器パート ];

				int instIndex = (int) pChip.e楽器パート;
                bool bRollChip = pChip.nチャンネル番号 >= 0x15 && pChip.nチャンネル番号 <= 0x19;

                if ( bRollChip && ( ( pChip.e楽器パート != E楽器パート.UNKNOWN ) && !pChip.bHit ) &&
				       ( ( pChip.nバーからの距離dot[ instIndex ] < -40 ) && ( this.e指定時刻からChipのJUDGEを返す( CSound管理.rc演奏用タイマ.n現在時刻, pChip, nInputAdjustTime ) == E判定.Miss ) ) )
				{
    			    this.tチップのヒット処理( CSound管理.rc演奏用タイマ.n現在時刻, pChip );
	    	    }

				switch ( pChip.nチャンネル番号 )
				{
                    #region[ 15-19: 連打 ]
                    case 0x15: //連打
                    case 0x16: //連打(大)
                    case 0x17: //風船
                    case 0x18: //連打終了
                    case 0x19:
                        {
                            this.t進行描画_チップ_Taiko連打( configIni, ref dTX, ref pChip );
                        }
                        break;
                    #endregion
                }

            }
			return false;
		}

        public void tBranchReset()
        {
            this.nBranch_roll = 0;
            this.nBranch_Perfect = 0;
            this.nBranch_Good = 0;
            this.nBranch_Miss = 0;
        }

        public void tBranchJudge( int n連打数, int n良, int n可, int n不可 )
        {
            if( this.b強制的に分岐させた ) return;

            int n種類 = CDTXMania.DTX.listBRANCH[this.n分岐した回数].n分岐の種類;

            double dbRate = 0;

            if( ( n良 + n可 + n不可 ) != 0 )
            {
                dbRate = ((double)n良 / (double)(n良 + n可 + n不可)) * 100.0;
            }


            if( n種類 == 0 )
            {
                if( dbRate < CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値A )
                {
                    this.n次回のコース = 0;
                }
                else if( dbRate >= CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値A && dbRate < CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値B )
                {
                    this.n次回のコース = 1;
                }
                else if( dbRate >= CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値B )
                {
                    this.n次回のコース = 2;
                }
            }
            else if( n種類 == 1 )
            {
                if( n連打数 < CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値A )
                {
                    this.n次回のコース = 0;
                }
                else if( n連打数 >= CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値A && n連打数 < CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値B )
                {
                    this.n次回のコース = 1;
                }
                else if( n連打数 >= CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値B )
                {
                    this.n次回のコース = 2;
                }

                this.nBranch_roll = 0;
            }
        }

        public int nBranchJudge( int n連打数, int n良, int n可, int n不可 )
        {

            int n種類 = CDTXMania.DTX.listBRANCH[this.n分岐した回数].n分岐の種類;
            int n次回のコース = 0;

            double dbRate = 0;

            if( ( n良 + n可 + n不可 ) != 0 )
            {
                dbRate = ((double)n良 / (double)(n良 + n可 + n不可)) * 100.0;
            }


            if( n種類 == 0 )
            {
                if( dbRate < CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値A )
                {
                    n次回のコース = 0;
                }
                else if( dbRate >= CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値A && dbRate < CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値B )
                {
                    n次回のコース = 1;
                }
                else if( dbRate >= CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値B )
                {
                    n次回のコース = 2;
                }
            }
            else if( n種類 == 1 )
            {
                if( n連打数 < CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値A )
                {
                    n次回のコース = 0;
                }
                else if( n連打数 >= CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値A && n連打数 < CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値B )
                {
                    n次回のコース = 1;
                }
                else if( n連打数 >= CDTXMania.DTX.listBRANCH[this.n分岐した回数].n条件数値B )
                {
                    n次回のコース = 2;
                }
            }

            return n次回のコース;
        }
        public void t分岐処理( int n分岐先, int n分岐開始位置のChip番号 )
        {
            int n消すコース1 = 1;
            int n消すコース2 = 2;

            switch( n分岐先 )
            {
                case 0:
                    n消すコース1 = 1;
                    n消すコース2 = 2;
                    break;
                case 1:
                    n消すコース1 = 0;
                    n消すコース2 = 2;
                    break;
                case 2:
                    n消すコース1 = 0;
                    n消すコース2 = 1;
                    break;
            }
            //2015.06.24 ソート処理で正確な番号が取得できなくなっていたので、とりあえずこれで対応。
            //2015.07.21 「卓球de脱臼」でバグが発生するのを修正完了。未ヒットチップを未来方向のみ検索して対応。
            

            //ソート後の譜面分岐開始位置のchip番号を正常に取得できないため、ここで現在の時刻から一番近い位置の音符を消す処理を作る必要がある。
            //CDTX.CChip chipNoHit = this.r指定時刻に一番近い未ヒットChip( CSound管理.rc演奏用タイマ.n現在時刻ms, 0xDF, 0, 10000 );
            CDTX.CChip chipNoHit = this.r指定時刻に一番近い未ヒットChip( CSound管理.rc演奏用タイマ.n現在時刻ms + 1, 0xDF, 0, 10000 ); //とりあえず検索開始を1ms後にして対応。
            if( chipNoHit == null )
                return;

            n分岐開始位置のChip番号 = chipNoHit.n整数値;
            

            for( int A = n分岐開始位置のChip番号; A < CDTXMania.DTX.listChip.Count; A++ )
            {
                //if( CDTXMania.DTX.listChip[ A ].n発声時刻ms < CDTXMania.DTX.listBRANCH[ this.n分岐した回数 ].db分岐時間ms )
                if( CDTXMania.DTX.listChip[ A ].n整数値 < n分岐開始位置のChip番号 )
                {
                    CDTXMania.DTX.listChip[ A ].b可視 = true;
                    continue;
                }

                if( CDTXMania.DTX.listChip[ A ].nチャンネル番号 == 0x01 ) continue;
                //if( CDTXMania.DTX.listChip[ A ].nチャンネル番号 == 0x50 ) continue;
                if( CDTXMania.DTX.listChip[ A ].nチャンネル番号 == 0x9C ) continue;
                if( CDTXMania.DTX.listChip[ A ].nチャンネル番号 == 0xDD ) continue;
                if( CDTXMania.DTX.listChip[ A ].nチャンネル番号 == 0xDE ) continue;
                if( CDTXMania.DTX.listChip[ A ].nチャンネル番号 == 0xDF ) continue;

                if( CDTXMania.DTX.listChip[ A ].nコース == n消すコース1 || CDTXMania.DTX.listChip[ A ].nコース == n消すコース2 )
                {
                    CDTXMania.DTX.listChip[ A ].b可視 = false;
                }
                else
                {
                    CDTXMania.DTX.listChip[ A ].b可視 = true;
                    CDTXMania.DTX.listChip[ A ].eNoteState = ENoteState.none;
                }
            }
        }

        protected float GetNowPBMTime( CDTX tja, float play_time )
        {
            float bpm_time = 0;
            int last_input = 0;
            float last_bpm_change_time;
            play_time = CSound管理.rc演奏用タイマ.n現在時刻ms - tja.nOFFSET;

            for (int i = 1; ; i++)
            {
                //BPMCHANGEの数越えた
                if( i >= CDTXMania.DTX.listBPM.Count )
                {
                    bpm_time = (float)CDTXMania.DTX.listBPM[ last_input ].bpm_change_bmscroll_time + ( ( play_time - (float)CDTXMania.DTX.listBPM[ last_input ].bpm_change_time ) * (float)CDTXMania.DTX.listBPM[ last_input ].dbBPM値 / 15000.0f );
                    last_bpm_change_time = (float)CDTXMania.DTX.listBPM[ last_input ].bpm_change_time;
                    break;
                }
                for( ; i < CDTXMania.DTX.listBPM.Count; i++ )
                {
                    if ( CDTXMania.DTX.listBPM[ i ].bpm_change_time == 0 || CDTXMania.DTX.listBPM[ i ].bpm_change_course == this.n現在のコース )
                    {
                        break;
                    }
                }
                if( i == CDTXMania.DTX.listBPM.Count )
                {
                    i = CDTXMania.DTX.listBPM.Count - 1;
                    continue;
                }

                if( play_time < CDTXMania.DTX.listBPM[ i ].bpm_change_time )
                {
                    bpm_time = (float)CDTXMania.DTX.listBPM[ last_input ].bpm_change_bmscroll_time + ( ( play_time - (float)CDTXMania.DTX.listBPM[ last_input ].bpm_change_time ) * (float)CDTXMania.DTX.listBPM[ last_input ].dbBPM値 / 15000.0f );
                    last_bpm_change_time = (float)CDTXMania.DTX.listBPM[ last_input ].bpm_change_time;
                    break;
                }
                else
                {
                    last_input = i;
                }
            }

            //for (int i = 0; ; i++)
            //{
            //    if( i >= CDTXMania.DTX.listDELAY.Count )
            //    {
                    return bpm_time;
            //    }
            //    //コースが異なる = 処理しない
            //    if( CDTXMania.DTX.listDELAY[ i ].delay_course != 0 && CDTXMania.DTX.listDELAY[ i ].delay_course != this.n現在のコース )
            //    {
            //        continue;
            //    }
            //    //停止時間が0以下 = 処理しない
            //    if( CDTXMania.DTX.listDELAY[ i ].nDELAY値 <= 0)
            //    {
            //        continue;
            //    }
            //    //処理済みのDELAY
            //    else if( play_time >= CDTXMania.DTX.listDELAY[ i ].delay_time + CDTXMania.DTX.listDELAY[ i ].nDELAY値 )
            //    {
            //        //最後のBPMCHANGEの処理以降のものであれば
            //        if( CDTXMania.DTX.listDELAY[ i ].delay_time > last_bpm_change_time )
            //        {
            //            bpm_time -= (float)CDTXMania.DTX.listDELAY[ i ].nDELAY値 * (float)CDTXMania.DTX.listDELAY[ i ].delay_bpm / 15000.0f;
            //        }
            //    }
            //    //DELAY処理終了
            //    else if( play_time < CDTXMania.DTX.listDELAY[ i ].delay_time )
            //    {
            //        return bpm_time;
            //    }
            //    //DELAY中
            //    else
            //    {
            //        return (float)CDTXMania.DTX.listDELAY[ i ].delay_bmscroll_time;
            //    }
            //}
            return -1;
        }

		public void t再読込()
		{
			CDTXMania.DTX.t全チップの再生停止とミキサーからの削除();
			this.eフェードアウト完了時の戻り値 = E演奏画面の戻り値.再読込_再演奏;
			base.eフェーズID = CStage.Eフェーズ.演奏_再読込;
			this.bPAUSE = false;
		}

        public void t演奏やりなおし()
        {
			CDTXMania.DTX.t全チップの再生停止とミキサーからの削除();
            this.t数値の初期化( true, true );
            this.actAVI.tReset();
            this.t演奏位置の変更( 0 );
            CDTXMania.stage演奏ドラム画面.On活性化();
            this.chip現在処理中の連打チップ = null;

            this.bPAUSE = false;
        }

		public void t停止()
		{
			CDTXMania.DTX.t全チップの再生停止とミキサーからの削除();
			this.actAVI.Stop();
			this.actPanel.Stop();				// PANEL表示停止
			CDTXMania.Timer.t一時停止();		// 再生時刻カウンタ停止

			this.n現在のトップChip = CDTXMania.DTX.listChip.Count - 1;	// 終端にシーク

			// 自分自身のOn活性化()相当の処理もすべき。
		}

        public void t数値の初期化( bool b演奏記録, bool b演奏状態 )
        {
            if( b演奏記録 )
            {
                this.nヒット数_Auto含む.Taiko.Perfect = 0;
                this.nヒット数_Auto含む.Taiko.Great = 0;
                this.nヒット数_Auto含む.Taiko.Good = 0;
                this.nヒット数_Auto含む.Taiko.Poor = 0;
                this.nヒット数_Auto含む.Taiko.Miss = 0;

                this.nヒット数_Auto含まない.Taiko.Perfect = 0;
                this.nヒット数_Auto含まない.Taiko.Great = 0;
                this.nヒット数_Auto含まない.Taiko.Good = 0;
                this.nヒット数_Auto含まない.Taiko.Poor = 0;
                this.nヒット数_Auto含まない.Taiko.Miss = 0;

                this.actCombo.On活性化();
                this.actScore.On活性化();
                this.actGauge.Init( CDTXMania.ConfigIni.nRisky );
            }
            if( b演奏状態 )
            {
                this.bIsGOGOTIME = false;
                this.bLEVELHOLD = false;
                this.b強制的に分岐させた = false;
                this.b譜面分岐中 = false;
                this.b連打中 = false;
                this.n現在のコース = 0;
                this.n次回のコース = 0;
                this.n現在の連打数 = 0;
                this.n合計連打数 = 0;
                this.n分岐した回数 = 0;

                this.actComboVoice.tリセット();
            }

            this.tスコアの初期化();
            this.nHand = 0;
        }

		public void t演奏位置の変更( int nStartBar )
		{
			// まず全サウンドオフにする
			CDTXMania.DTX.t全チップの再生停止();
			this.actAVI.Stop();

			#region [ 再生開始小節の変更 ]
			nStartBar++;									// +1が必要

			#region [ 演奏済みフラグのついたChipをリセットする ]
			for ( int i = 0; i < CDTXMania.DTX.listChip.Count; i++ )
			{
				CDTX.CChip pChip = CDTXMania.DTX.listChip[ i ];
				if ( pChip.bHit )
				{
					CDTX.CChip p = (CDTX.CChip) pChip.Clone();
					p.bHit = false;
					CDTXMania.DTX.listChip[ i ] = p;

                    //2016.11.23 kairera0467 太鼓用に追加
                    p.eNoteState = ENoteState.none;
                    p.nProcessTime = 0;
				}
			}
			#endregion

			#region [ 処理を開始するチップの特定 ]
			//for ( int i = this.n現在のトップChip; i < CDTXMania.DTX.listChip.Count; i++ )
			bool bSuccessSeek = false;
			for ( int i = 0; i < CDTXMania.DTX.listChip.Count; i++ )
			{
				CDTX.CChip pChip = CDTXMania.DTX.listChip[ i ];
				if ( pChip.n発声位置 < 384 * nStartBar )
				{
					continue;
				}
				else
				{
					bSuccessSeek = true;
					this.n現在のトップChip = i;
					break;
				}
			}
			if ( !bSuccessSeek )
			{
				// this.n現在のトップChip = CDTXMania.DTX.listChip.Count - 1;
				this.n現在のトップChip = 0;		// 対象小節が存在しないなら、最初から再生
			}
			#endregion

			#region [ 演奏開始の発声時刻msを取得し、タイマに設定 ]
			int nStartTime = CDTXMania.DTX.listChip[ this.n現在のトップChip ].n発声時刻ms;

			CSound管理.rc演奏用タイマ.tリセット();	// これでPAUSE解除されるので、次のPAUSEチェックは不要
			//if ( !this.bPAUSE )
			//{
				CSound管理.rc演奏用タイマ.t一時停止();
			//}
			CSound管理.rc演奏用タイマ.n現在時刻 = nStartTime;
			#endregion

			List<CSound> pausedCSound = new List<CSound>();

			#region [ BGMやギターなど、演奏開始のタイミングで再生がかかっているサウンドのの途中再生開始 ] // (CDTXのt入力_行解析_チップ配置()で小節番号が+1されているのを削っておくこと)
			for ( int i = this.n現在のトップChip; i >= 0; i-- )
			{
				CDTX.CChip pChip = CDTXMania.DTX.listChip[ i ];
				int nDuration = pChip.GetDuration();

				if ( ( pChip.n発声時刻ms + nDuration > 0 ) && ( pChip.n発声時刻ms <= nStartTime ) && ( nStartTime <= pChip.n発声時刻ms + nDuration ) )
				{
					if ( pChip.bWAVを使うチャンネルである && ( pChip.nチャンネル番号 >> 4 ) != 0xB )	// wav系チャンネル、且つ、空打ちチップではない
					{
						CDTX.CWAV wc;
						bool b = CDTXMania.DTX.listWAV.TryGetValue( pChip.n整数値_内部番号, out wc );
						if ( !b ) continue;

						if ( ( wc.bIsBGMSound && CDTXMania.ConfigIni.bBGM音を発声する ) || ( !wc.bIsBGMSound ) )
						{
							CDTXMania.DTX.tチップの再生( pChip, CSound管理.rc演奏用タイマ.n前回リセットした時のシステム時刻 + pChip.n発声時刻ms, (int) Eレーン.BGM, CDTXMania.DTX.nモニタを考慮した音量( E楽器パート.UNKNOWN ) );
							#region [ PAUSEする ]
							int j = wc.n現在再生中のサウンド番号;
							if ( wc.rSound[ j ] != null )
							{
							    wc.rSound[ j ].t再生を一時停止する();
							    wc.rSound[ j ].t再生位置を変更する( nStartTime - pChip.n発声時刻ms );
							    pausedCSound.Add( wc.rSound[ j ] );
							}
							#endregion
						}
					}
				}
			}
			#endregion
			#region [ 演奏開始時点で既に表示されているBGAとAVIの、シークと再生 ]
			this.actAVI.SkipStart( nStartTime );
			#endregion
			#region [ PAUSEしていたサウンドを一斉に再生再開する(ただしタイマを止めているので、ここではまだ再生開始しない) ]
			foreach ( CSound cs in pausedCSound )
			{
				cs.tサウンドを再生する();
			}
			pausedCSound.Clear();
			pausedCSound = null;
			#endregion
			#region [ タイマを再開して、PAUSEから復帰する ]
			CSound管理.rc演奏用タイマ.n現在時刻 = nStartTime;
			CDTXMania.Timer.tリセット();						// これでPAUSE解除されるので、3行先の再開()は不要
			CDTXMania.Timer.n現在時刻 = nStartTime;				// Debug表示のTime: 表記を正しくするために必要
			CSound管理.rc演奏用タイマ.t再開();
			//CDTXMania.Timer.t再開();
			this.bPAUSE = false;								// システムがPAUSE状態だったら、強制解除
			this.actPanel.Start();
			#endregion
			#endregion
		}

        public void t演奏中止()
        {
            this.actFO.tフェードアウト開始();
            base.eフェーズID = CStage.Eフェーズ.共通_フェードアウト;
            this.eフェードアウト完了時の戻り値 = E演奏画面の戻り値.演奏中断;
        }

		/// <summary>
		/// DTXV用の設定をする。(全AUTOなど)
		/// 元の設定のバックアップなどはしないので、あとでConfig.iniを上書き保存しないこと。
		/// </summary>
		protected void tDTXV用の設定()
		{
			CDTXMania.ConfigIni.bAutoPlay.HH = true;
			CDTXMania.ConfigIni.bAutoPlay.SD = true;
			CDTXMania.ConfigIni.bAutoPlay.BD = true;
			CDTXMania.ConfigIni.bAutoPlay.HT = true;
			CDTXMania.ConfigIni.bAutoPlay.LT = true;
			CDTXMania.ConfigIni.bAutoPlay.CY = true;
			CDTXMania.ConfigIni.bAutoPlay.FT = true;
			CDTXMania.ConfigIni.bAutoPlay.RD = true;
			CDTXMania.ConfigIni.bAutoPlay.LC = true;
            CDTXMania.ConfigIni.bAutoPlay.LP = true;
            CDTXMania.ConfigIni.bAutoPlay.LBD = true;
			CDTXMania.ConfigIni.bAutoPlay.GtR = true;
			CDTXMania.ConfigIni.bAutoPlay.GtB = true;
			CDTXMania.ConfigIni.bAutoPlay.GtB = true;
			CDTXMania.ConfigIni.bAutoPlay.GtPick = true;
			CDTXMania.ConfigIni.bAutoPlay.GtW = true;
			CDTXMania.ConfigIni.bAutoPlay.BsR = true;
			CDTXMania.ConfigIni.bAutoPlay.BsB = true;
			CDTXMania.ConfigIni.bAutoPlay.BsB = true;
			CDTXMania.ConfigIni.bAutoPlay.BsPick = true;
			CDTXMania.ConfigIni.bAutoPlay.BsW = true;

			this.bIsAutoPlay = CDTXMania.ConfigIni.bAutoPlay;

			CDTXMania.ConfigIni.bAVI有効 = true;
			CDTXMania.ConfigIni.bBGA有効 = true;
			for ( int i = 0; i < 3; i++ )
			{
				CDTXMania.ConfigIni.bGraph[ i ] = false;
				CDTXMania.ConfigIni.bHidden[ i ] = false;
				CDTXMania.ConfigIni.bLeft[ i ] = false;
				CDTXMania.ConfigIni.bLight[ i ] = false;
				CDTXMania.ConfigIni.bReverse[ i ] = false;
				CDTXMania.ConfigIni.bSudden[ i ] = false;
				CDTXMania.ConfigIni.eInvisible[ i ] = EInvisible.OFF;
				CDTXMania.ConfigIni.eRandom[ i ] = Eランダムモード.OFF;
				CDTXMania.ConfigIni.n表示可能な最小コンボ数[ i ] = 65535;
				CDTXMania.ConfigIni.判定文字表示位置[ i ] = E判定文字表示位置.表示OFF;
				// CDTXMania.ConfigIni.n譜面スクロール速度[ i ] = CDTXMania.ConfigIni.nViewerScrollSpeed[ i ];	// これだけはOn活性化()で行うこと。
																												// そうしないと、演奏開始直後にスクロール速度が変化して見苦しい。
			}

			CDTXMania.ConfigIni.eDark = Eダークモード.OFF;

			CDTXMania.ConfigIni.b演奏情報を表示する = CDTXMania.ConfigIni.bViewerShowDebugStatus;
			CDTXMania.ConfigIni.bフィルイン有効 = true;
			CDTXMania.ConfigIni.bScoreIniを出力する = false;
			CDTXMania.ConfigIni.bSTAGEFAILED有効 = false;
			CDTXMania.ConfigIni.bTight = false;
			CDTXMania.ConfigIni.bストイックモード = false;

			CDTXMania.ConfigIni.nRisky = 0;
			CDTXMania.ConfigIni.nShowLagType = 0;
			CDTXMania.ConfigIni.bドラムコンボ表示 = true;
		}


		private bool bCheckAutoPlay( CDTX.CChip pChip )
		{
            if( pChip.nチャンネル番号 >= 0x11 && pChip.nチャンネル番号 <= 0x1F )
                return true;

			return true;
		}

		protected abstract void t進行描画_チップ_ドラムス( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip );
		protected abstract void t進行描画_チップ本体_ドラムス( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip );
		protected abstract void t進行描画_チップ_Taiko( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip );
		protected abstract void t進行描画_チップ_Taiko連打( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip );

		protected abstract void t進行描画_チップ_フィルイン( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip );
		protected abstract void t進行描画_チップ_小節線( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip );
		protected void t進行描画_チップアニメ()
		{
            if( this.b初めての進行描画 )
            {
                this.n制御タイマ = FDK.CSound管理.rc演奏用タイマ.n現在時刻;
            }

            long num = FDK.CSound管理.rc演奏用タイマ.n現在時刻;
			if( num < this.n制御タイマ )
			{
				this.n制御タイマ = num;
			}
			while( ( num - this.n制御タイマ ) >= 1000 )
			{
				if( this.n現在の音符の顔番号 == 0 )
				{
					this.n現在の音符の顔番号 = 1;
		        }
				else if( this.n現在の音符の顔番号 == 1 )
				{
					this.n現在の音符の顔番号 = 0;
		        }

                if( this.actCombo.n現在のコンボ数.Drums < 50 )
                {
                    this.n制御タイマ += 500;
                }
                else if(this.actCombo.n現在のコンボ数.Drums >= 50 && this.actCombo.n現在のコンボ数.Drums < 150)
                {
                    this.n制御タイマ += 400;
                }
                else if( this.actCombo.n現在のコンボ数.Drums >= 150 && this.actCombo.n現在のコンボ数.Drums < 250 )
                {
                    this.n制御タイマ += 300;
                }
                else if( this.actCombo.n現在のコンボ数.Drums >= 250 && this.actCombo.n現在のコンボ数.Drums < 300 )
                {
                    this.n制御タイマ += 200;
                }
                else if( this.actCombo.n現在のコンボ数.Drums >= 300 )
                {
                    this.n制御タイマ += 80;
                }
                else
                {
                    this.n制御タイマ += 500;
                }

		    }

            if( this.actChara.ctゴーゴーモーション != null )
            {
                this.actChara.ctゴーゴーモーション.t進行LoopDb();
            }
		}

		protected bool t進行描画_フェードイン_アウト()
		{
			switch ( base.eフェーズID )
			{
				case CStage.Eフェーズ.共通_フェードイン:
					if ( this.actFI.On進行描画() != 0 )
					{
						base.eフェーズID = CStage.Eフェーズ.共通_通常状態;
					}
					break;

				case CStage.Eフェーズ.共通_フェードアウト:
				case CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト:
					if ( this.actFO.On進行描画() != 0 )
					{
						return true;
					}
					break;

				case CStage.Eフェーズ.演奏_STAGE_CLEAR_フェードアウト:
					if ( this.actFOClear.On進行描画() == 0 )
					{
						break;
					}
					return true;
		
			}
			return false;
		}
		protected void t進行描画_レーンフラッシュD()
		{
			//if ( ( CDTXMania.ConfigIni.eDark == Eダークモード.OFF ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				this.actLaneFlushD.On進行描画();
			}
		}
		protected abstract void t進行描画_演奏情報();
		protected void t進行描画_演奏情報(int x, int y)
		{
			if ( !CDTXMania.ConfigIni.b演奏情報を表示しない )
			{
				this.actPlayInfo.t進行描画( x, y );
			}
		}
		protected void t進行描画_背景()
		{
			if ( this.tx背景 != null )
			{
				this.tx背景.t2D描画( CDTXMania.app.Device, 0, 0 );
			}
		}

		protected void t進行描画_判定ライン()
		{
			if ( CDTXMania.ConfigIni.eDark != Eダークモード.FULL )
			{
				int y = CDTXMania.ConfigIni.bReverse.Drums ? 53 - 演奏判定ライン座標.nJudgeLinePosY_delta.Drums : 567 + 演奏判定ライン座標.nJudgeLinePosY_delta.Drums;
																// #31602 2013.6.23 yyagi 描画遅延対策として、判定ラインの表示位置をオフセット調整できるようにする
				if ( this.txヒットバー != null )
				{
				    this.txヒットバー.t2D描画( CDTXMania.app.Device, 295, y, new Rectangle( 0, 0, 558, 6 ) );
				}
			}
		}
		protected void t進行描画_判定文字列()
		{
			this.actJudgeString.t進行描画( 演奏判定ライン座標 );
		}
		protected void t進行描画_判定文字列1_通常位置指定の場合()
		{
			if ( ( (E判定文字表示位置) CDTXMania.ConfigIni.判定文字表示位置.Drums ) != E判定文字表示位置.コンボ下 )	// 判定ライン上または横
			{
				this.actJudgeString.t進行描画( 演奏判定ライン座標 );
			}
		}
		protected void t進行描画_判定文字列2_判定ライン上指定の場合()
		{
			if ( ( (E判定文字表示位置) CDTXMania.ConfigIni.判定文字表示位置.Drums ) == E判定文字表示位置.コンボ下 )	// 判定ライン上または横
			{
				this.actJudgeString.t進行描画( 演奏判定ライン座標 );
			}
		}

		protected void t進行描画_譜面スクロール速度()
		{
			this.act譜面スクロール速度.On進行描画();
		}
        protected abstract void t紙吹雪_開始();
		protected abstract void t背景テクスチャの生成();
		protected void t背景テクスチャの生成( string DefaultBgFilename, Rectangle bgrect, string bgfilename )
		{
            try
            {
                if( !String.IsNullOrEmpty( bgfilename ) )
                    this.tx背景 = CDTXMania.tテクスチャの生成( CDTXMania.stage選曲.r確定されたスコア.ファイル情報.フォルダの絶対パス + bgfilename );
                else
                    this.tx背景 = CDTXMania.tテクスチャの生成( CSkin.Path( DefaultBgFilename ) );
            }
            catch
            {
                this.tx背景 = null;
            }
		}

        protected void tスコアの初期化()
        {
            //一打目の処理落ちがひどいので、あらかじめここで点数の計算をしておく。
            int nInit = CDTXMania.DTX.nScoreInit[ 0, CDTXMania.stage選曲.n確定された曲の難易度 ];
            int nDiff = CDTXMania.DTX.nScoreDiff[ CDTXMania.stage選曲.n確定された曲の難易度 ];
            int nAddScore = 0;
            int[] n倍率 = { 0, 1, 2, 4, 8 };

            if( CDTXMania.DTX.nScoreModeTmp == 1 )
            {
                for( int i = 0; i < 11; i++ )
                {
                    this.nScore[ i ] = (int)( nInit + ( nDiff * ( i ) ) );
                }
            }
            else if( CDTXMania.DTX.nScoreModeTmp == 2 )
            {
                for( int i = 0; i < 5; i++ )
                {
                    this.nScore[ i ] = (int)( nInit + ( nDiff * n倍率[ i ] ) );

                    this.nScore[ i ] = (int)( this.nScore[ i ] / 10.0 );
                    this.nScore[ i ] = this.nScore[ i ] * 10;

                }

                //this.nScore[ 0 ] = (int)nInit;
                //this.nScore[ 1 ] = (int)( nInit + nDiff );
                //this.nScore[ 2 ] = (int)( nInit + ( nDiff * 2 ) );
                //this.nScore[ 3 ] = (int)( nInit + ( nDiff * 4 ) );
                //this.nScore[ 4 ] = (int)( nInit + ( nDiff * 8 ) );
            }
        }
        #endregion
	}
}
