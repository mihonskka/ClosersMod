using ClosersFramework.KeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Services
{
	public static class EventDispatcher
	{
		/*
		添加事件[异步]：
		EventDispatcher.AddAction(EventKeys.Key_PageUp, async _ =>
		{
			await InvokeAsync(StateHasChanged);
		});

		添加事件[同步]:
		EventDispatcher.AddAction(EventKeys.Key_PageUp, _ =>
		{
			Console.WriteLine("HelloWorld");
		});

		触发事件：
		EventDispatcher.Dispatch(EventKeys.Key_PageUp, null);

		移除事件：
		EventDispatcher.RemoveAction(EventKeys.Key_PageUp);
		 */

		static Dictionary<string, List<Action<object>>> _actions = new Dictionary<string, List<Action<object>>>();

		/// <summary>
		/// 登记事件 和 处理方法
		/// </summary>
		/// <param name="key"></param>
		/// <param name="action"></param>
		/// <exception cref="Exception"></exception>
		public static int AddAction(string key, Action<object> action)
		{
			if (!_actions.ContainsKey(key))
			{
                _actions.Add(key, new List<Action<object>>() { action });
				return -1;
            }
				
			else
			{
				//throw new Exception($"事件key{key}已经存在！");
				clog.w($"事件key{key}已经存在，将在其下挂载方法，该方法的下标为{_actions[key].Count}！");
				_actions[key].Add(action);
				return _actions[key].Count - 1;
			}
		}

		public static void AddExceptList(List<string> input)
		{
			ExceptList.AddRange(input);
			ExceptList = ExceptList.Distinct().ToList();
		}

		static List<string> ExceptList = new List<string>();
		public static void ClearInBattleAction()
		{
			var RemoveList = _actions.Keys.Where(t => !ExceptList.Contains(t)).ToList();
			RemoveList.ForEach(t => RemoveAction(t));
        }

		/// <summary>
		/// 移除登记的事件
		/// </summary>
		/// <param name="key"></param>
		public static void RemoveAction(string key)
		{
			if (_actions.ContainsKey(key))
				_actions.Remove(key);
		}
        public static void RemoveByStartWith(string key)
        {
            var match = _actions?.Where(t => t.Key.StartsWith(key)).Select(t => t.Key).ToList();
			clog.w($"前缀删除，匹配数量：{match.Count()}，匹配的的密钥为：{string.Join(",", match)}");
			if (match.Any())
				for (int i = 0; i < match.Count(); i++)
					RemoveAction(match[i]);
        }
        public static void DispatchByStartWith(string prefix, object value=null)
		{
			var match = _actions?.Where(t => t.Key.StartsWith(prefix));
			if(match.Any())
			{
				clog.w($"DispatchByStartWith-消息分发成功，匹配订阅者数量：{match.Count()}，订阅者分别为：{match.FirstOrDefault().Key}、{match.LastOrDefault().Key}");
                var act = _actions[_actions.FirstOrDefault().Key];
				act.ForEach(t => t.Invoke(value ?? string.Empty));
			}
        }

		/// <summary>
		/// 发送事件 和 处理参数
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>

		public static void Dispatch(string key, object value=null)
		{
			clog.w("Dispatch");
			clog.w(string.Join(",", _actions.Keys));
			if (_actions.ContainsKey(key))
			{
				var act = _actions[key];
				act.ForEach(t => t.Invoke(value ?? string.Empty));
			}

		}
	}
}
