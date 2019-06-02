
[![wercker status](https://app.wercker.com/status/3ce6ec1904a51afc60821482412506f0/s/master "wercker status")](https://app.wercker.com/project/byKey/3ce6ec1904a51afc60821482412506f0)

# Location Reporter

这是 Location Reporter 微服务。

这个服务是《ASP.NET Core 微服务实战》一书中，事件溯源和 CQRS 示例中使用的多个微服务的一部分。这个示例扮演其中*命令提交者*的角色，各个应用会消费这一服务来指示已发现一个团队成员的新位置。由于这只是一个简单的示例服务，它只有一个命令可供提交（即提交并报送位置），真实世界中的例子通常会提交多个命令服务，以负责处理更多种类型的命令。

这个服务接着将命令转换为事件，典型情况下是从命令的正文转换而来（从把一个表示意图的表达式，比如*请记录此团队成员的位置*，转换成一个在过去已经发生的事件，比如*团队成员的位置已记录*）。

此服务的 API 相当简单：

|Resource|Method|Description|
|---|---|---|
|/api/members/{memberId}/locationreports|POST|向服务提交一个新的位置报送记录|


