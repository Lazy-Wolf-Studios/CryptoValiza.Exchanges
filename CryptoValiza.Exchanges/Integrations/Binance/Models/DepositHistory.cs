namespace CryptoValiza.Exchanges.Binance.Models;

internal class DepositHistory
{
	/*
	{
        "id": "769800519366885376",
        "amount": "0.001",
        "coin": "BNB",
        "network": "BNB",
        "status": 0,
        "address": "bnb136ns6lfw4zs5hg4n85vdthaad7hq5m4gtkgf23",
        "addressTag": "101764890",
        "txId": "98A3EA560C6B3336D348B6C83F0F95ECE4F1F5919E94BD006E5BF3BF264FACFC",
        "insertTime": 1661493146000,
        "transferType": 0,
        "confirmTimes": "1/1",
        "unlockConfirm": 0,
        "walletType": 0
    }

	 */

	public string Id { get; set; }
	public decimal Amount { get; set; }
	public string Coin { get; set; }
	public string Network { get; set; }
	public int Status { get; set; } // enum ??
	/*(0:pending, 6: credited but cannot withdraw, 1:success)
     */

	public string Address { get; set; }
	public string AddressTag { get; set; }
	public string TxId { get; set; }


	public long InsertTime { get; set; }
	public int TransferType { get; set; } // 1 for internal transfer, 0 for external transfer   
	public string ConfirmTimes { get; set; }
	public int UnlockConfirm { get; set; }
	public int WalletType { get; set; } // 1: Funding Wallet 0:Spot Wallet
}
