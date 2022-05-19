namespace CryptoValiza.Exchanges.Kuna.Models;
public class Currency
{
	int Id { get; set; }                 //  "id": 2,            # internal ID
	string Code { get; set; }            //  "code": "btc",      # currency symbol
	string Name { get; set; }            //  "name": "Bitcoin",  # currency name
										 //public bool Has_Memo { get; set; }          //  "has_memo": false,  
										 //public Icons Icons { get; set; }            //  "icons": { }        
	bool Coin { get; set; }              //  "coin": true,       # is crypto
	string Explorer_Link { get; set; }   //  "explorer_link": "https://www.blockchain.com/btc/tx/#{txid}",
										 //                      # link template for TXID in explorer
	int Sort_Order { get; set; }         //  "sort_order": 5,    
										 //Precision Precision { get; set; }    //  "precision": { }    
}
