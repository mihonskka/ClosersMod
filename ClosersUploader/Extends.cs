using ChronoArkMod.ModData;
using ChronoArkMod;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersUploader
{
	public class Extends
	{
		public static void CreateItem(string path, ModInfo modInfo, EWorkshopFileType fileType, ERemoteStoragePublishedFileVisibility visibility, string changeNote)
		{
			SteamAPICall_t hAPICall = SteamUGC.CreateItem(SteamWorkShop._appId, fileType);
			CallResult<CreateItemResult_t>.Create(null).Set(hAPICall, delegate (CreateItemResult_t result, bool failed)
			{
				if (result.m_bUserNeedsToAcceptWorkshopLegalAgreement)
				{
					string str = "You need to accept the Steam Workshop legal agreement for this game before you can upload items!";
					Console.WriteLine("Fail to Upload", modInfo.Title + "\n" + str);
					return;
				}
				if (result.m_eResult == EResult.k_EResultOK)
				{
					modInfo.WorkShopId = result.m_nPublishedFileId.m_PublishedFileId.ToString();
					modInfo.SaveWorkShopId();
					UploadItemUpdate(path, modInfo, fileType, visibility, changeNote, true);
				}
			});
		}

		public static void UploadItemUpdate(string path, ModInfo modInfo, EWorkshopFileType fileType, ERemoteStoragePublishedFileVisibility visibility, string changeNote, bool AfterCreate = false)
		{
			Steamworks.SteamAPI.Init();
			PublishedFileId_t publishedFileId_t = new PublishedFileId_t(Convert.ToUInt64(modInfo.WorkShopId));
			UGCUpdateHandle_t ugcupdateHandle_t = SteamUGC.StartItemUpdate(SteamWorkShop._appId, publishedFileId_t);
			if (modInfo.OnlyUploadFiles && !AfterCreate)
			{
				if (!SteamUGC.SetItemContent(ugcupdateHandle_t, path))
				{
					Console.WriteLine("Fail to Upload " + modInfo.Title, "Fail to set content at " + path);
					return;
				}
				SubmitUpdate(ugcupdateHandle_t, modInfo, changeNote);
				return;
			}
			else
			{
				if (!SteamUGC.SetItemTitle(ugcupdateHandle_t, modInfo.Title))
				{
					Console.WriteLine("Fail to Upload " + modInfo.Title, "Fail to set title " + path);
					return;
				}
				if (!SteamUGC.SetItemDescription(ugcupdateHandle_t, modInfo.Description))
				{
					Console.WriteLine("Fail to Upload " + modInfo.Title, "Fail to set description " + path);
					return;
				}
				if (!SteamUGC.SetItemContent(ugcupdateHandle_t, path))
				{
					Console.WriteLine("Fail to Upload " + modInfo.Title, "Fail to set content at " + path);
					return;
				}
				if (!SteamUGC.SetItemTags(ugcupdateHandle_t, modInfo.TagList))
				{
					Console.WriteLine("Fail to Upload " + modInfo.Title, "Fail to set tags of count " + modInfo.TagList.Count);
					return;
				}
				if (!SteamUGC.SetItemVisibility(ugcupdateHandle_t, visibility))
				{
					Console.WriteLine("Fail to Upload " + modInfo.Title, "Fail to set description " + visibility);
					return;
				}
				if (string.IsNullOrEmpty(modInfo.Cover))
				{
					Console.WriteLine("Fail to Upload " + modInfo.Title, "Empty cover path ");
					return;
				}
				string text = Path.Combine(path, modInfo.Cover);
				if (!File.Exists(text))
				{
					Console.WriteLine("Fail to Upload " + modInfo.Title, "Cover at [" + text + "] does not exsits");
					return;
				}
				if (!SteamUGC.SetItemPreview(ugcupdateHandle_t, text))
				{
					Console.WriteLine("Fail to Upload " + modInfo.Title, "Fail to set cover at [" + text + "]");
					return;
				}
				foreach (string text2 in modInfo.Dependencies)
				{
					if (ModManager.AllModIDs.Contains(text2))
					{
						string workShopId = ModManager.getModInfo(text2).WorkShopId;
						if (!workShopId.IsNullOrEmpty())
						{
							SteamUGC.AddDependency(publishedFileId_t, new PublishedFileId_t(Convert.ToUInt64(workShopId)));
						}
					}
				}
				SubmitUpdate(ugcupdateHandle_t, modInfo, changeNote);
				return;
			}
		}

		// Token: 0x060041AD RID: 16813 RVA: 0x001BBEA4 File Offset: 0x001BA0A4
		public static void SubmitUpdate(UGCUpdateHandle_t ugcupdateHandle_t, ModInfo modInfo, string changeNote)
		{
			CallResult<SubmitItemUpdateResult_t>.Create(null).Set(SteamUGC.SubmitItemUpdate(ugcupdateHandle_t, changeNote), delegate (SubmitItemUpdateResult_t pCallback, bool bIOFailure)
			{
				if (pCallback.m_eResult == EResult.k_EResultOK)
				{
					Console.WriteLine("Upload Sucessfully");
					return;
				}
				Console.WriteLine("Fail to Upload");
			});
			while (true)
			{
				ulong num;
				ulong num2;
				var status = SteamUGC.GetItemUpdateProgress(ugcupdateHandle_t, out num, out num2);
				if (num < num2)
				{
					if (num2 > 0UL)
					{
						Console.WriteLine(string.Format("Upload progress: {0}/{1}", num, num2));
					}
				}
				else
				{
					return;
				}
			}
		}

		// Token: 0x04003F18 RID: 16152
		public static AppId_t _appId = (AppId_t)1188930U;
	}
}
