# ConsumerDrivenContracts
PoC for consumer driven contract testing. The gist is as follows:

1. Consumer adds a new field to the object that it recieves from the provider API/message.
2. This updated schema is published to a contract broker (in this case a document store).
3. The provider API/service in its contract tests loads the latest version of the consumer's contract from the broker and verifies if provider object's schema matches the consumer's expectation or not. If not then the test fails. You then add the missing field of appropriate type to the provider's object schema, re-run the tests and this time it should pass.

The consumer shares its `consumer-key` with the provider, where a `consumer-key` is endpoint specific for e.g. `restocking-pg-sqs-reordermoment-msg` can be the consumer key for PG that dequeues a Product with reorder moment calculated and this key can then be shared with PIS so it can run its consumer contract tests. 

Each `consumer-key` can have one or more contract versions for e.g. if the Product object schema changes for the above mentioned `consumer-key`, then we will store the new schema in the broker, with an updated timestamp and then the `GetLatestConsumerContract` call in provider side consumer contract tests will return this schema.

## This PoC doesn't use any specialised Pact testing tools or frameworks with the hope that that will keep it playing nice with CI.

# Things that still need addressing and sorting

1. Automatically publish the consumer contract when it changes preferably during CI. Manually updating it is a cognitive overhead that's no better than remembering to add fields on both sides.

2. Store the field name along with its data type, so not only field name check but type checking can also be done.

3. Establish a way to register the consumer with the provider using the same consumer key with which the contract is published to the broker.

4. Fine tune the contract/schema versioning such that only the latest schema is loaded.
