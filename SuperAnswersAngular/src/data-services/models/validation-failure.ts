/* tslint:disable */

/**
 * Defines a validation failure
 */
export interface ValidationFailure {

  /**
   * The name of the property.
   */
  propertyName?: string;

  /**
   * The error message
   */
  errorMessage?: string;

  /**
   * The property value that caused the failure.
   */
  attemptedValue?: any;

  /**
   * Custom state associated with the failure.
   */
  customState?: any;

  /**
   * Custom severity level associated with the failure.
   */
  severity: any;

  /**
   * Gets or sets the error code.
   */
  errorCode?: string;

  /**
   * Gets or sets the formatted message arguments.
   * These are values for custom formatted message in validator resource files
   * Same formatted message can be reused in UI and with same number of format placeholders
   * Like "Value {0} that you entered should be {1}"
   */
  formattedMessageArguments?: Array<any>;

  /**
   * Gets or sets the formatted message placeholder values.
   */
  formattedMessagePlaceholderValues?: {[key: string]: any};

  /**
   * The resource name used for building the message
   */
  resourceName?: string;
}
