using ChronoArkMod.ModData;
using ClosersIseubi.KeyWords;
using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ClosersIseubi.FrontScripts
{
	[Obsolete]
	public class SandAnimation:MonoBehaviour
	{
		public RectTransform targetUIElement; // 你的UI控件
		public float particleSpeed = 0.5f;
		public int particleCount = 500;

		private List<GameObject> particles = new List<GameObject>();
		private Vector3[] targetPositions;
		private bool positionsGenerated = false;

		void Start()
		{
			targetUIElement = (RectTransform)this.transform;
			
			// 生成沙子颗粒
			for (int i = 0; i < particleCount; i++)
			{
				var particle = AddressableLoadManager.Instantiate(new GDEGameobjectDatasData(IseubiKeyWords.Closers_Sylvi_SandUnit).Gameobject_Path, AddressableLoadManager.ManageType.Character, this.transform);
				particle.transform.position = GetRandomStartPosition();
				particle.transform.localScale = new Vector3(5, 5, 5);
				particles.Add(particle);
				//Destroy(particle,10);
			}

			// 生成目标位置（UI控件轮廓）
			GenerateTargetPositions();
		}
		Vector3 GetRandomStartPosition()
		{
			var _RectTransform = (FieldSystem.instance.PartyWindow[0].transform as RectTransform);
			var Postion = _RectTransform.anchoredPosition;
			Postion.x = Postion.x + _RectTransform.rect.width * 0.5f;

			var startPoint = UGUIToWorldPosition(Postion, GameObject.Find("Canvas2D").GetComponent<Canvas>());
			// 从屏幕外或随机位置开始
			//return Camera.main.ScreenToWorldPoint(new Vector3(
			//Random.Range(0, Screen.width),
			//Random.Range(0, Screen.height),
			//10));

			return startPoint;
			return Camera.main.ScreenToWorldPoint(new Vector3(
				startPoint.x,
				startPoint.y,
				10));
		}

		void GenerateTargetPositions()
		{
			if (targetUIElement == null) return;

			// 获取UI的四个角作为基础轮廓
			Vector3[] corners = new Vector3[4];
			targetUIElement.GetWorldCorners(corners);

			// 创建更密集的点集（插值）
			targetPositions = new Vector3[particleCount];
			for (int i = 0; i < particleCount; i++)
			{
				float t = (float)i / (particleCount - 1);
				int segment = Mathf.FloorToInt(t * 4); // 简单分为3段
				float segmentT = (t * 4) - segment;

				// 在两个角之间插值
				Vector3 p1 = corners[segment % 4];
				Vector3 p2 = corners[(segment + 1) % 4];
				targetPositions[i] = Vector3.Lerp(p1, p2, segmentT);

				// 添加一些随机偏移使效果更自然
				targetPositions[i] += Random.insideUnitSphere * 0.05f;
			}

			positionsGenerated = true;
		}
		void Update()
		{
			if (!positionsGenerated) return;

			for (int i = 0; i < particles.Count; i++)
			{
				if (i >= targetPositions.Length) break;

				// 移动颗粒向目标位置
				particles[i].transform.position = Vector3.Lerp(
					particles[i].transform.position,
					targetPositions[i],
					particleSpeed * Time.deltaTime);

				// 可选：随着接近目标改变大小或颜色
				//float distance = Vector3.Distance(
				//	particles[i].transform.position,
				//	targetPositions[i]);
				//float scale = Mathf.Lerp(0.5f, 1f, 1 - distance);
				//particles[i].transform.localScale = Vector3.one * scale;
			}
		}


		/// <summary>
		/// 将 UGUI 坐标（屏幕坐标）转换为世界坐标。
		/// </summary>
		/// <param name="uiPosition">UGUI 的 RectTransform 坐标（通常是锚点中心或鼠标点击位置）。</param>
		/// <param name="canvas">UGUI 所在的 Canvas 对象。</param>
		/// <param name="zOffset">世界坐标中的 Z 偏移量（可选，默认为 0）。</param>
		/// <returns>转换后的世界坐标（Vector3）。</returns>
		public static Vector3 UGUIToWorldPosition(Vector2 uiPosition, Canvas canvas, float zOffset = 0)
		{
			// 检查 Canvas 的渲染模式
			if (canvas.renderMode != RenderMode.ScreenSpaceOverlay)
			{
				// 如果 Canvas 不是 ScreenSpaceOverlay 模式，需要使用 RectTransformUtility.ScreenPointToWorldPointInRectangle
				RectTransform canvasRect = canvas.GetComponent<RectTransform>();
				Vector3 worldPosition;
				RectTransformUtility.ScreenPointToWorldPointInRectangle(
					canvasRect,
					uiPosition,
					canvas.worldCamera,
					out worldPosition
				);
				worldPosition.z = zOffset; // 设置 Z 偏移量
				return worldPosition;
			}
			else
			{
				// 如果是 ScreenSpaceOverlay 模式，直接使用屏幕坐标转换为世界坐标
				Vector3 screenPosition = new Vector3(uiPosition.x, uiPosition.y, zOffset);
				return Camera.main.ScreenToWorldPoint(screenPosition);
			}
		}
	}
}
