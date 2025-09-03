using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Validators;

public class CustomerValidator
{
    public static string CustomerNotFound(Customer  customer)
    {
        string error;
        if (customer == null)
            error = "Customer not Found.";

        else
            error = "Customer Found.";
        return error;
    }

    public static List<string> InputValidator(string firstName, string lastName, string? email, string phoneNumber)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(firstName))
            errors.Add("FirstName is required");

        if (string.IsNullOrWhiteSpace(lastName))
            errors.Add("LastName is required");

        if (email != null && !email.Contains("@"))
            errors.Add("Email must contain  @ symbol");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            errors.Add("PhoneNumber is required.");

        return errors;
    }

    public static string UpdateNameInputValidator(string firstName)
    {
        string error;
        if (string.IsNullOrWhiteSpace(firstName))
            error = "FirstName is required";

        else
            error = "FirstName Accepted";
        return error;
    }

    public static string UpdateLastNameInputValidator(string lastName)
    {
        string error;
        if (string.IsNullOrWhiteSpace(lastName))
            error = "LastName is required";

        else
            error = "LastName Accepted";
        return error;
    }

    public static string UpdateEmailInputValidator(string email)
    {
        string error;
        if (email != null && !email.Contains("@"))
            error = "Email must contain  @ symbol";

        else
            error = "Email Accepted";
        return error;
    }

    public static string UpdatePhoneInputValidator(string phoneNumber)
    {
        string error;
        if (string.IsNullOrWhiteSpace(phoneNumber))
            error = "PhoneNumber is required.";

        else
            error = "PhoneNumber Accepted";
        return error;
    }
}
