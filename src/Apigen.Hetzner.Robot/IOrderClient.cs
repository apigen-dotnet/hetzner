using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for order operations
/// </summary>
public partial interface IOrderClient
{
  /// <summary>
  /// Get all currently offered standard server products
  /// Operation: GET /order/server/product
  /// </summary>
  Task<List<OrderServerProductGetAllResponse>> OrderServerProductGetAllAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Get data of a specific standard server product
  /// Operation: GET /order/server/product/{product_id}
  /// </summary>
  Task<OrderServerProductGetResponse> GetAsync(string productId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all standard server orders of the last 30 days
  /// Operation: GET /order/server/transaction
  /// </summary>
  Task<List<OrderServerTransactionGetAllResponse>> OrderServerTransactionGetAllAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Order a standard server
  /// Operation: POST /order/server/transaction
  /// </summary>
  Task<OrderServerResponse> OrderServerAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Query the status of a specific server order
  /// Operation: GET /order/server/transaction/{transaction_id}
  /// </summary>
  Task<OrderServerTransactionGetResponse> GetOrderServerTransactionAsync(string transactionId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all currently offered server market products
  /// Operation: GET /order/server_market/product
  /// </summary>
  Task<List<OrderServerMarketProductGetAllResponse>> OrderServerMarketProductGetAllAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Get data of a specifi server market product
  /// Operation: GET /order/server_market/product/{product_id}
  /// </summary>
  Task<OrderServerMarketProductGetResponse> GetAsync(int productId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all server market orders of the last 30 days
  /// Operation: GET /order/server_market/transaction
  /// </summary>
  Task<List<OrderServerMarketTransactionGetAllResponse>> OrderServerMarketTransactionGetAllAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Order a server from the server market
  /// Operation: POST /order/server_market/transaction
  /// </summary>
  Task<OrderMarketServerResponse> OrderMarketServerAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Query the status of a specific server market order
  /// Operation: GET /order/server_market/transaction/{transaction_id}
  /// </summary>
  Task<OrderServerMarketTransactionGetResponse> GetOrderServerMarketTransactionAsync(int transactionId, CancellationToken cancellationToken = default);

}
