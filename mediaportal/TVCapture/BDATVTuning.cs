using System;
using System.Collections;
using System.Windows.Forms;
using DShowNET;
using MediaPortal.TV.Database;

namespace MediaPortal.TV.Recording
{

	/// <summary>
	/// Summary description for BDATVTuning.
	/// </summary>
	public class BDATVTuning : ITuning
	{
		TVCaptureDevice											captureCard;
		AutoTuneCallback										callback = null;
		public BDATVTuning()
		{
		}
		#region ITuning Members

		public void AutoTuneTV(TVCaptureDevice card, AutoTuneCallback statusCallback)
		{
			captureCard=card;
			callback=statusCallback;
			if (!card.CreateGraph())
			{
				card.DeleteGraph();
				callback.OnProgress(100);
				callback.OnEnded();
				return;
			}
			if (captureCard.Network== NetworkType.DVBT)
			{
				// Todo:create DVBT tuning
				return;
			}


			card.DeleteGraph();
			callback.OnProgress(100);
			callback.OnEnded();
			return;
		}

		public void AutoTuneRadio(TVCaptureDevice card, AutoTuneCallback callback)
		{
			// TODO:  Add BDATVTuning.AutoTuneRadio implementation
		}

		public void Continue()
		{
			// TODO:  Add BDATVTuning.Continue implementation
		}

		public int MapToChannel(string channel)
		{
			// TODO:  Add BDATVTuning.MapToChannel implementation
			return 0;
		}

		#endregion
	}
}
