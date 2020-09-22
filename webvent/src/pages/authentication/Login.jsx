import React from 'react';
import ReactDOM from 'react-dom';
import 'antd/dist/antd.css';
import { Form, Input, Button, Checkbox } from 'antd';
import { UserOutlined, LockOutlined } from '@ant-design/icons';
 
const Login = () => {
  const onFinish = (values) => {
    console.log('Received values of form: ', values);
  };

  return (
    <Form
      name="normal_login"
      className="login-form"
      initialValues={{ remember: true }}
      onFinish={onFinish}
    >
      <Form.Item name="username"
          rules={[
            {
              required: true,
              message: 'Escriba su usuario',
            },
          ]}
       >
        <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Usuario" />
      </Form.Item>
      <Form.Item name="password"
          rules={[
            {
              required: true,
              message: 'Escriba su contraseña',
            },
          ]}
       >
        <Input  prefix={<LockOutlined className="site-form-item-icon" />}
              type="password"
              placeholder="Contraseña" />
      </Form.Item>
      <Form.Item>
        <Form.Item name="remember" valuePropName="checked" noStyle>
          <Checkbox>Recordar</Checkbox>
        </Form.Item>

        <a className="login-form-forgot" href="">
          Olvide mi contraseña
        </a>
      </Form.Item>

      <Form.Item>
        <Button type="primary" htmlType="submit" className="login-form-button">
          Iniciar sesión
        </Button>
        o <a href="">registrarme</a>
      </Form.Item>
    </Form>
  );
};


export default Login;