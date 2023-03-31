/* Value types: 
 * -> contain their data, stored in stack.
 * -> int, float, enum, bool, struct
 * -> can't be null. (have default values)
 * -> default values;
 *    -> int, short, long => 0
 *    -> float, double => 0.0
 *    -> char => '\u0000'
 *    -> bool => false
 * Referance types: 
 * -> store references to their data, referances also store
 *    in stack, but their values are in heap.
 * -> class, object, array, string
 * -> can be null
 */

/* Naming conventions
 * Pascal Case: UserAccount, EmailAddress, DoesMemberExist
 * Camel Case: getUserInfo, orderId, templateFilePath
 * Kebab Case: koton-puzzle-crm-customer-service, v3db-test, api-token
 * Snake Case: first_name, Email_Address, Test_score
 * Screaming Case: SMTP_PORT, TAX_RATE
 * 
 * Use PascalCase when creating classes and methods
 * Use camelCase wen decralring variables, arguments
 * Don't use abbreviations
 * Your variable names should make sense
 * You can use underscore if needed (e.g. colorway_code)
 * Don't use reserved keywords for your variable names
 */

