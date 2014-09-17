﻿#region License
// 
//     CoiniumServ - Crypto Currency Mining Pool Server Software
//     Copyright (C) 2013 - 2014, CoiniumServ Project - http://www.coinium.org
//     http://www.coiniumserv.com - https://github.com/CoiniumServ/CoiniumServ
// 
//     This software is dual-licensed: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//    
//     For the terms of this license, see licenses/gpl_v3.txt.
// 
//     Alternatively, you can license this software under a commercial
//     license or white-label it as set out in licenses/commercial.txt.
// 
#endregion
using System;
using System.Collections.Generic;
using CoiniumServ.Accounts;
using CoiniumServ.Miners;
using CoiniumServ.Payments;
using CoiniumServ.Persistance.Blocks;
using CoiniumServ.Server.Mining.Stratum;
using CoiniumServ.Shares;

namespace CoiniumServ.Persistance.Layers
{
    public interface IStorageLayer
    {

        bool IsEnabled { get; }

        #region share storage

        void AddShare(IShare share);

        void RemoveShares(IPaymentRound round);

        void MoveShares(IShare share);

        void MoveSharesToCurrentRound(IPersistedBlock block);

        Dictionary<string, double> GetCurrentShares();

        Dictionary<string, double> GetShares(IPersistedBlock block);

        void DeleteExpiredHashrateData(int until);

        IDictionary<string, double> GetHashrateData(int since);

        #endregion

        #region block storage

        void AddBlock(IShare share);

        void UpdateBlock(IPersistedBlock block);

        IDictionary<string, int> GetTotalBlocks();

        IEnumerable<IPersistedBlock> GetAllUnpaidBlocks();

        IEnumerable<IPersistedBlock> GetAllPendingBlocks(); 

        IEnumerable<IPersistedBlock> GetLastBlocks(int count = 20);

        #endregion

        #region account storage

        void AddAccount(IAccount user);

        IAccount GetAccount(string username);

        IAccount GetAccountById(int id);

        bool Authenticate(IMiner miner);

        void UpdateDifficulty(IStratumMiner miner);

        #endregion

        #region payments storage

        void CommitPayoutsForRound(IPaymentRound round);

        IList<IPayment> GetPendingPayouts();

        void UpdatePayout(IPayment payout);

        void AddTransaction(ITransaction transaction);

        #endregion
    }
}
