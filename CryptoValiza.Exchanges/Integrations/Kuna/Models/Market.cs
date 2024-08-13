namespace CryptoValiza.Exchanges.Kuna.Models;
internal class Market
{
	string Id { get; set; }              // "id": "btcusdt",       
	string Base_Unit { get; set; }       // "base_unit": "btc",    
	string Quote_Unit { get; set; }      // "quote_unit": "usdt",  
	int Base_Precision { get; set; }     // "base_precision": 6,   
	int Quote_Precision { get; set; }    // "quote_precision": 2,  
	int Display_Precision { get; set; }  // "display_precision": 1,
	decimal Price_Change { get; set; }   // "price_change": -1.89  
}
