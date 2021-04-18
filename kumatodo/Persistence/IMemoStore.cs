using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kumatodo.Model;

namespace kumatodo.Persistence
{
    public interface IMemoStore
    {
        /// <summary>
        /// メモ一覧取得
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Memo>> GetMemosAsync();

        /// <summary>
        /// idにより、メモを取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Memo> GetMemo(int id);

        /// <summary>
        /// メモを追加
        /// </summary>
        /// <param name="memo"></param>
        /// <returns></returns>
        Task AddMemo(Memo memo);

        /// <summary>
        /// メモを削除
        /// </summary>
        /// <param name="memo"></param>
        /// <returns></returns>
        Task DeleteMemo(Memo memo);

        /// <summary>
        /// メモを更新
        /// </summary>
        /// <param name="memo"></param>
        /// <returns></returns>
        Task UpdateMemo(Memo memo);

    }
}
